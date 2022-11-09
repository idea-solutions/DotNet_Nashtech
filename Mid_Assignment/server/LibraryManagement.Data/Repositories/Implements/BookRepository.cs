using System.Linq.Expressions;
using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryManagementContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetAllIncludedAsync(Expression<Func<Book, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                .Include(book => book.Categories)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdIncludedAsync(Expression<Func<Book, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                .Include(book => book.Categories)
                .FirstOrDefaultAsync();
        }
    }
}