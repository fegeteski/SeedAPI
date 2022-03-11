using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.Context
{
    public class SeedDbContext : DbContext
    {
        public SeedDbContext(DbContextOptions<SeedDbContext> options) : base(options)
        {

        }
        public DbSet<Seed> Seed { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
