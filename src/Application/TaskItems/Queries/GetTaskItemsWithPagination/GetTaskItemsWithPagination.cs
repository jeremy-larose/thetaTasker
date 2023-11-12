using thetaREST.Application.Common.Interfaces;
using thetaREST.Application.Common.Mappings;
using thetaREST.Application.Common.Models;

namespace thetaREST.Application.TaskItems.Queries.GetTaskItemsWithPagination;

public record GetTaskItemsWithPaginationQuery : IRequest<PaginatedList<TaskItemDigestDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTaskItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTaskItemsWithPaginationQuery, PaginatedList<TaskItemDigestDto>>
{
    public async Task<PaginatedList<TaskItemDigestDto>> Handle(GetTaskItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.TaskItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TaskItemDigestDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
