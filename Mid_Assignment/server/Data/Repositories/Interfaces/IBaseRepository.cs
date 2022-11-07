using System.Linq.Expressions;
using Data.Entities;

namespace Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}