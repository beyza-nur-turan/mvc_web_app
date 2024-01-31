using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext//veritabanını temsil edecek
    {
        public DbSet<Product> Products { get; set; } //product modelindeki verileri alıp productsları oluşturacak yapı

        public RepositoryContext(DbContextOptions<RepositoryContext> options)//dbcontext isteğiyle gelen bir istek derlenemez 
        //demek istedik. yani ne zaman veritabanına ihtiyaç olursa o zaman bir dbcontext nesnesi olulması şart olacak
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>() //veri varsa eklemiycek veri yoksa aşağıdakileri ekler
            .HasData(
                new Product() { productId = 1, productName = "Computer", price = 20_000 },
                new Product() { productId = 2, productName = "Keyboard", price = 1_000 },
                new Product() { productId = 3, productName = "Mouse", price = 500 },
                new Product() { productId = 4, productName = "Monitor", price = 10_000 },
                new Product() { productId = 5, productName = "Deck", price = 1_500 }
            );
        }
    }
}