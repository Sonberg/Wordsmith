namespace Wordsmith.Core.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using Models;

    public interface IDatabaseContext
    {
        DbSet<WordTransformation>? WordTransformations { get; set; }
    }

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<WordTransformation>? WordTransformations { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("Host=localhost;Database=Wordsmith");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // var converter = new ValueConverter<string, Guid>(
            //         v => Guid.Parse(v),
            //         v => v.ToString());

            // modelBuilder.Entity<WordTransformation>()
            //   .Property(s => s.Id)
            //   .HasConversion(converter);

            base.OnModelCreating(modelBuilder);
        }
    }
}

