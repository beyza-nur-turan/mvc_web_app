using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.productId);
            builder.Property(p=>p.productName).IsRequired();
            builder.Property(p=>p.price).IsRequired();
            builder.HasData(
                                    new Product() { productId = 1, CategoryId = 2, productName = "Computer", price = 20_000 },
                    new Product() { productId = 2, CategoryId = 2, productName = "Keyboard", price = 1_000 },
                    new Product() { productId = 3, CategoryId = 2, productName = "Mouse", price = 500 },
                    new Product() { productId = 4, CategoryId = 2, productName = "Monitor", price = 10_000 },
                    new Product() { productId = 5, CategoryId = 2, productName = "Deck", price = 1_500 },
                    new Product() { productId = 6, CategoryId = 1, productName = "Detective", price = 150 },
                    new Product() { productId = 7, CategoryId = 1, productName = "History", price = 200 }
            );
        }

    }
}