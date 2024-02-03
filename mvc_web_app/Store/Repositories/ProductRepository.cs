using Entities.Models;
using Repositories.Contracts;
using Repositories;
namespace Repositories
{
    public class ProductRepository :RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(RepositoryContext context) :base(context)
        {

        }
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        
        //Interface id ye göre ürün getirme
        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p=>p.productId.Equals(id),trackChanges);
        }
    }
}