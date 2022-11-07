using System.Linq.Expressions;
using Data.Entities;

namespace Data.Repositories
{
    public interface IBookBorrowingRequestRepository : IBaseRepository<BookBorrowingRequest>
    {
        Task<IEnumerable<BookBorrowingRequest>> GetAllIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null);
        Task<BookBorrowingRequest?> GetByIdIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null);
    }
}