using thetaREST.Domain.Entities;

namespace thetaREST.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TaskList> TaskLists { get; }

    DbSet<TaskItem> TaskItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
