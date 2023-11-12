using thetaREST.Application.Common.Interfaces;

namespace thetaREST.Application.TaskLists.Commands.DeleteTaskList;

public record DeleteTaskListCommand(int Id) : IRequest;

public class DeleteTaskListCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTaskListCommand>
{
    public async Task Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TaskLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.TaskLists.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}
