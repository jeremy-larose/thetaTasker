using thetaREST.Domain.Entities;

namespace thetaREST.Application.TaskLists.Queries.GetTasks;

public class TaskListDto
{
    public TaskListDto()
    {
        Items = Array.Empty<TaskItemDto>();
    }

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<TaskItemDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TaskList, TaskListDto>();
        }
    }
}
