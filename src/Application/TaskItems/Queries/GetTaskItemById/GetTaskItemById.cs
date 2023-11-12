using thetaREST.Application.Common.Interfaces;
using thetaREST.Application.Common.Mappings;

namespace Microsoft.Extensions.DependencyInjection.TaskItems.Queries;

public record GetTaskItemByIdQuery : IRequest<TaskItemDto>
{
    public int? Id { get; init; }
}

public class GetTaskItemByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTaskItemByIdQuery, TaskItemDto?>
{
    public async Task<TaskItemDto?> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await context.TaskItems
            .Where(x=>x.Id == request.Id)
            .ProjectToSingleOrDefaultAsync<TaskItemDto>(mapper.ConfigurationProvider);

        return item;
    }
}
