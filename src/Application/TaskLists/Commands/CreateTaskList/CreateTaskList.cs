using thetaREST.Application.Common.Interfaces;
using thetaREST.Domain.Entities;

namespace thetaREST.Application.TaskLists.Commands.CreateTaskList;

public record CreateTaskListCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateTaskListCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTaskListCommand, int>
{
    public async Task<int> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TaskList();

        entity.Title = request.Title;

        context.TaskLists.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
