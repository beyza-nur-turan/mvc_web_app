using Repositories.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new() // tipin referans tipli ve newlenebilir
                           //instance oluşturabilir tipte olduğunu gösteririz 
    {
        protected readonly RepositoryContext _context;
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges 
            ? _context.Set<T>() 
            : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }
    }
}