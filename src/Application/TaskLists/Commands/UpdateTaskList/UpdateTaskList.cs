using thetaREST.Application.Common.Interfaces;

namespace thetaREST.Application.TaskLists.Commands.UpdateTaskList;

public record UpdateTaskListCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateTaskListCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTaskListCommand>
{
    public async Task Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TaskLists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;

        await context.SaveChangesAsync(cancellationToken);

    }
}
