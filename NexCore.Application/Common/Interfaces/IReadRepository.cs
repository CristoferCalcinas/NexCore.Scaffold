using Ardalis.Specification;

namespace NexCore.Application.Common.Interfaces;

/// <summary>
/// Contrato de solo lectura (NoTracking) para queries sobre AggregateRoots.
/// </summary>
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class;
