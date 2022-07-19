using Microsoft.EntityFrameworkCore;
using scorecard_performance_tracker.Models;

namespace scorecard_performance_tracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Score> Scores { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(entry => entry.Entity is BaseEntity);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((BaseEntity)entry.Entity).Id = Guid.NewGuid().ToString();
                        ((BaseEntity)entry.Entity).CreationTime = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
