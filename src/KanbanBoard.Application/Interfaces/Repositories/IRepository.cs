using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Application.Interfaces.Repositories
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null);
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
