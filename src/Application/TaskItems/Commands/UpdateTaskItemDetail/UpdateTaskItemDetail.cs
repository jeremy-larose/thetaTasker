using thetaREST.Application.Common.Interfaces;
using thetaREST.Domain.Enums;

namespace thetaREST.Application.TaskItems.Commands.UpdateTaskItemDetail;

public record UpdateTaskItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTaskItemDetailCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTaskItemDetailCommand>
{
    public async Task Handle(UpdateTaskItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TaskItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        await context.SaveChangesAsync(cancellationToken);
    }
}
