namespace NexCore.Domain.Common;

/// <summary>
/// Marker interface para que el interceptor de EF Core detecte
/// entidades auditables y complete automáticamente los campos de auditoría.
/// </summary>
public interface IAuditableEntity
{
    DateTimeOffset CreatedOnUtc { get; set; }
    string? CreatedBy { get; set; }
    DateTimeOffset? ModifiedOnUtc { get; set; }
    string? ModifiedBy { get; set; }
}