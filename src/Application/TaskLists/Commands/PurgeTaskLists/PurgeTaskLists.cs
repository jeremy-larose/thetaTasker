using thetaREST.Application.Common.Interfaces;
using thetaREST.Application.Common.Security;
using thetaREST.Domain.Constants;

namespace thetaREST.Application.TaskLists.Commands.PurgeTaskLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTaskListsCommand : IRequest;

public class PurgeTaskListsCommandHandler(IApplicationDbContext context) : IRequestHandler<PurgeTaskListsCommand>
{
    public async Task Handle(PurgeTaskListsCommand request, CancellationToken cancellationToken)
    {
        context.TaskLists.RemoveRange(context.TaskLists);

        await context.SaveChangesAsync(cancellationToken);
    }
}
