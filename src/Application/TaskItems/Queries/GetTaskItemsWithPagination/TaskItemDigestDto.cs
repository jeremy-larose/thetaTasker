using thetaREST.Domain.Entities;

namespace thetaREST.Application.TaskItems.Queries.GetTaskItemsWithPagination;

public class TaskItemDigestDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TaskItem, TaskItemDigestDto>();
        }
    }
}
