using Microsoft.EntityFrameworkCore;

namespace WebAppDocker.Database.Entities
{
    public class WebAppDockerDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public WebAppDockerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Product>()
                .ToTable("products")
                .HasKey("Id");

        }
    }
}
