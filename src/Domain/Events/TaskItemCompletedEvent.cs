namespace thetaREST.Domain.Events;

public class TaskItemCompletedEvent(TaskItem item) : BaseEvent
{
    public TaskItem Item { get; } = item;
}
