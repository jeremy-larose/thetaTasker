using thetaREST.Domain.Entities;
using thetaREST.Domain.Enums;

namespace Microsoft.Extensions.DependencyInjection.TaskItems.Queries;

public class TaskItemDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
    
    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public string? Note { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TaskItem, TaskItemDto>();
        }
    }
}
