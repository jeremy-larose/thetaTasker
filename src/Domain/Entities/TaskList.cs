namespace thetaREST.Domain.Entities;

public class TaskList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public IList<TaskItem> Items { get; private set; } = new List<TaskItem>();
}
