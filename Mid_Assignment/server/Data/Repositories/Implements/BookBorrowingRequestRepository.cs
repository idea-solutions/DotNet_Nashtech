
using System.Linq.Expressions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BookBorrowingRequest>> GetAllIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                            .Include(br => br.RequestedByUserId)
                            .Include(br => br.StatusUpdateByUserId)
                            .Include(br => br.Books)
                            .ToListAsync();
        }

        public async Task<BookBorrowingRequest?> GetByIdIncludedAsync(Expression<Func<BookBorrowingRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            if (dbSet == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _context.Database.BeginTransactionAsync();

            try
            {
                await dbSet
                        .Include(br => br.RequestedByUserId)
                        .Include(br => br.StatusUpdateByUserId)
                        .Include(br => br.Books)
                        .FirstOrDefaultAsync();

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return await dbSet
                    .Include(br => br.RequestedByUserId)
                    .Include(br => br.StatusUpdateByUserId)
                    .Include(br => br.Books)
                    .FirstOrDefaultAsync();
        }

    }
}