using Microsoft.EntityFrameworkCore;
using Entities.Models; // Doğru isim uzayını ekleyin

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { productId = 1, productName = "Computer", price = 20_000 },
                    new Product() { productId = 2, productName = "Keyboard", price = 1_000 },
                    new Product() { productId = 3, productName = "Mouse", price = 500 },
                    new Product() { productId = 4, productName = "Monitor", price = 10_000 },
                    new Product() { productId = 5, productName = "Deck", price = 1_500 }
                );
            modelBuilder.Entity<Category>()
            .HasData(
                new Category() { CategoryId = 1, CategoryName = "Books" },
                new Category() { CategoryId = 2, CategoryName = "Electronic" }
            );
        }
    }
}
