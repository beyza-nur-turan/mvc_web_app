using Repositories.Contracts; // IRepositoryManager ve IProductRepository burada bulunuyor
namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product {get;}
        ICategoryRepository Category {get;}
        IOrderRepository Order {get;}
        void Save();
    }
}