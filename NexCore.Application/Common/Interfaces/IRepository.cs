using Ardalis.Specification;

namespace NexCore.Application.Common.Interfaces;

/// <summary>
/// Contrato genérico de escritura para AggregateRoots. Usar con T : AggregateRoot(TId).
/// </summary>
public interface IRepository<T> : IRepositoryBase<T> where T : class;
