using Microsoft.EntityFrameworkCore;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Category>()
                .HasMany<Product>().WithOne().HasForeignKey(p => p.CategoryId);
        }
    }

}
