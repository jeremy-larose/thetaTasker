using thetaREST.Application.Common.Models;

namespace thetaREST.Application.TaskLists.Queries.GetTasks;

public class TasksVm
{
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = Array.Empty<LookupDto>();

    public IReadOnlyCollection<TaskListDto> Lists { get; init; } = Array.Empty<TaskListDto>();
}
