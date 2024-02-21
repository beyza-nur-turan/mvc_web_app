using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //alternatif yol
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());
           //üstteki yolda hepsini tek tek tanımlamamız gerekecekti ama altta 
           //ne kadar varsa hepsinin ayarlamasını yapıyor.
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        } 
    }
}
