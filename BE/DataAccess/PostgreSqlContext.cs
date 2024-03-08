using Microsoft.EntityFrameworkCore;
using BE.Models;

namespace BE.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Set> Set { get; set; }
        public DbSet<Routine> Routine { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseNpgsql()
        .UseSnakeCaseNamingConvention();

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}