using System.Linq.Expressions;
using LibraryManagement.Data.Entities;

namespace LibraryManagement.Data.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllIncludedAsync(Expression<Func<Book, bool>>? predicate = null);
        Task<Book?> GetByIdIncludedAsync(Expression<Func<Book, bool>>? predicate = null);
    }
}