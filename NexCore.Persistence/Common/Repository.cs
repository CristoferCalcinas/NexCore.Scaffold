using Ardalis.Specification.EntityFrameworkCore;
using NexCore.Application.Common.Interfaces;

namespace NexCore.Persistence.Common;

public class Repository<T>(AppDbContext dbContext)
    : RepositoryBase<T>(dbContext), IRepository<T>
    where T : class;