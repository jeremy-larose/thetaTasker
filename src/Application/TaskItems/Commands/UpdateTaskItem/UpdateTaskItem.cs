using thetaREST.Application.Common.Interfaces;

namespace thetaREST.Application.TaskItems.Commands.UpdateTaskItem;

public record UpdateTaskItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTaskItemCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTaskItemCommand>
{
    public async Task Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Done = request.Done;

        await context.SaveChangesAsync(cancellationToken);
    }
}
