namespace Wordsmith.Core.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public interface IDatabaseContext
    {
        DbSet<WordTransformation> WordTransformations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken ct);
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<WordTransformation> WordTransformations { get; set; }

        public DatabaseContext(): base()
        {
            this.Database.EnsureCreated();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

