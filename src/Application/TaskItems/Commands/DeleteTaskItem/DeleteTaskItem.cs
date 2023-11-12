using thetaREST.Application.Common.Interfaces;
using thetaREST.Domain.Events;

namespace thetaREST.Application.TaskItems.Commands.DeleteTaskItem;

public record DeleteTaskItemCommand(int Id) : IRequest;

public class DeleteTaskItemCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTaskItemCommand>
{
    public async Task Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.TaskItems.Remove(entity);

        entity.AddDomainEvent(new TaskItemDeletedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);
    }

}
