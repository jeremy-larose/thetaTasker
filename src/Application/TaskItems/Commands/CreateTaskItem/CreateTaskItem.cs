using thetaREST.Application.Common.Interfaces;
using thetaREST.Domain.Entities;
using thetaREST.Domain.Events;

namespace thetaREST.Application.TaskItems.Commands.CreateTaskItem;

public record CreateTaskItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTaskItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTaskItemCommand, int>
{
    public async Task<int> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TaskItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TaskItemCreatedEvent(entity));

        context.TaskItems.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
