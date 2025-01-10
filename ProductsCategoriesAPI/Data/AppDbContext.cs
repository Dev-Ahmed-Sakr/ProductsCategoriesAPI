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

            // Configure Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.ParentCategory)
                      .WithMany()
                      .HasForeignKey(e => e.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
            });

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Specify desired delete behavior
            });
        }
    }

}
