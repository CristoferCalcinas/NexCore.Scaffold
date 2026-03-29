using Ardalis.Specification.EntityFrameworkCore;
using NexCore.Application.Common.Interfaces;

namespace NexCore.Persistence.Common;

public class ReadRepository<T>(AppReadDbContext dbContext) :
    RepositoryBase<T>(dbContext), IReadRepository<T>
    where T : class;