using Microsoft.EntityFrameworkCore;

namespace Services.Identity.Data
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}