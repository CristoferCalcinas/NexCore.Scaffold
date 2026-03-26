namespace NexCore.Domain.Common;

public abstract class BaseAuditableEntity<TId> : Entity<TId>, IAuditableEntity
    where TId : notnull
{
    protected BaseAuditableEntity(TId id) : base(id)
    {
    }

    protected BaseAuditableEntity()
    {
    } // Required for EF Core

    public DateTimeOffset CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? ModifiedOnUtc { get; set; }
    public string? ModifiedBy { get; set; }
}