using Microsoft.EntityFrameworkCore;

namespace NexCore.Persistence.Common;

public class AppReadDbContext(DbContextOptions<AppReadDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppReadDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
