namespace NexCore.Domain.Common;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("General.Null", "Se proporcionó un valor nulo.");

    public static Error NotFound(string resource) =>
        new($"{resource}.NotFound", $"{resource} no fue encontrado.");

    public static Error Validation(string field, string description) =>
        new($"Validation.{field}", description);

    public static Error Conflict(string resource) =>
        new($"{resource}.Conflict", $"{resource} ya existe.");

    public static Error Unauthorized() =>
        new("General.Unauthorized", "No tiene permisos para realizar esta acción.");
}