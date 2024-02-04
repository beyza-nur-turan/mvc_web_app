using System.Linq.Expressions;
using Repositories.Contracts; // IRepositoryBase<> interface'i burada bulunuyor
namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create (T entity);
        void Remove(T entity);
    }
}