using System.Reflection;
using thetaREST.Application.Common.Exceptions;
using thetaREST.Application.Common.Interfaces;
using thetaREST.Application.Common.Security;

namespace thetaREST.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse>(IUser user,
    IIdentityService identityService) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        var attributes = authorizeAttributes.ToList();
        if (attributes.Count is not 0)
        {
            // Must be authenticated user
            if (user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }

            // Role-based authorization
            var authorizeAttributesWithRoles = attributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

            var attributesWithRoles = authorizeAttributesWithRoles.ToList();
            if (attributesWithRoles.Count is not 0)
            {
                var authorized = false;

                foreach (var roles in attributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = await identityService.IsInRoleAsync(user.Id, role.Trim());
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }

                // Must be a member of at least one role in roles
                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            // Policy-based authorization
            var authorizeAttributesWithPolicies = attributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
            var attributesWithPolicies = authorizeAttributesWithPolicies.ToList();
            if (attributesWithPolicies.Count is not 0)
            {
                foreach (var policy in attributesWithPolicies.Select(a => a.Policy))
                {
                    var authorized = await identityService.AuthorizeAsync(user.Id, policy);

                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }
        }

        // User is authorized / authorization not required
        return await next();
    }
}
