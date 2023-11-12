namespace thetaREST.Domain.Events;

public class TaskItemDeletedEvent(TaskItem item) : BaseEvent
{
    public TaskItem Item { get; } = item;
}
