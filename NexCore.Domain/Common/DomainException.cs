namespace NexCore.Domain.Common;

/// <summary>
/// Excepción base para violaciones de reglas de dominio.
/// Cada bounded context debe definir su propia excepción concreta heredando de esta.
/// </summary>
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }

    protected DomainException(string message, Exception inner) : base(message, inner)
    {
    }
}