using System.Linq.Expressions;
using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(LibraryManagementContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BookBorrowingRequest>> GetAllIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                    .Include(br => br.RequestedBy)
                    .Include(br => br.StatusUpdateBy)
                    .Include(br => br.Books)
                    .ToListAsync();
        }

        public async Task<BookBorrowingRequest?> GetByIdIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                    .Include(br => br.RequestedBy)
                    .Include(br => br.StatusUpdateBy)
                    .Include(br => br.Books)
                    .FirstOrDefaultAsync();
        }
    }
}