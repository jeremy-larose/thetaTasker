using thetaREST.Domain.Events;
using Microsoft.Extensions.Logging;

namespace thetaREST.Application.TaskItems.EventHandlers;

public class TaskItemCompletedEventHandler(ILogger<TaskItemCompletedEventHandler> logger) : INotificationHandler<TaskItemCompletedEvent>
{
    public Task Handle(TaskItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("thetaREST Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
