using thetaREST.Application.Common.Interfaces;
using thetaREST.Application.Common.Models;
using thetaREST.Application.Common.Security;
using thetaREST.Domain.Enums;

namespace thetaREST.Application.TaskLists.Queries.GetTasks;

[Authorize]
public record GetTasksQuery : IRequest<TasksVm>;

public class GetTasksQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTasksQuery, TasksVm>
{
    public async Task<TasksVm> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        return new TasksVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto { Id = (int)p, Title = p.ToString() })
                .ToList(),

            Lists = await context.TaskLists
                .AsNoTracking()
                .ProjectTo<TaskListDto>(mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
