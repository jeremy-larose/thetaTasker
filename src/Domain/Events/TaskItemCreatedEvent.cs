namespace thetaREST.Domain.Events;

public class TaskItemCreatedEvent(TaskItem item) : BaseEvent
{
    public TaskItem Item { get; } = item;
}
