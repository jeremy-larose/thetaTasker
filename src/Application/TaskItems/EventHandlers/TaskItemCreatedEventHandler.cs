using thetaREST.Domain.Events;
using Microsoft.Extensions.Logging;

namespace thetaREST.Application.TaskItems.EventHandlers;

public class TaskItemCreatedEventHandler(ILogger<TaskItemCreatedEventHandler> logger) : INotificationHandler<TaskItemCreatedEvent>
{
    public Task Handle(TaskItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("thetaREST Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
