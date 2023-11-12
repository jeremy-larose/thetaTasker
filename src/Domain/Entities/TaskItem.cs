namespace thetaREST.Domain.Entities;

public class TaskItem : BaseAuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new TaskItemCompletedEvent(this));
            }

            _done = value;
        }
    }

    public TaskList List { get; set; } = null!;
}
