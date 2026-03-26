using System.Reflection;

namespace NexCore.Domain.Common;

/// <summary>
/// Alternativa a los enums primitivos de C#. Permite adjuntar comportamiento
/// a cada valor. Ejemplo: OrderStatus.Submitted, CardType.Visa.
/// </summary>
public abstract class Enumeration : IComparable
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;

    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public static T? FromId<T>(int id) where T : Enumeration =>
        GetAll<T>().FirstOrDefault(e => e.Id == id);

    public static T? FromName<T>(string name) where T : Enumeration =>
        GetAll<T>().FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public override bool Equals(object? obj) =>
        obj is Enumeration other && GetType() == other.GetType() && Id == other.Id;

    public override int GetHashCode() => Id.GetHashCode();

    public int CompareTo(object? other) => Id.CompareTo(((Enumeration)other!).Id);
}