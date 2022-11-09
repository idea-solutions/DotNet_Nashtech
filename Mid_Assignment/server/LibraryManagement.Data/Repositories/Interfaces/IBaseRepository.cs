using LibraryManagement.Data.Entities;
using System.Linq.Expressions;

namespace LibraryManagement.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}