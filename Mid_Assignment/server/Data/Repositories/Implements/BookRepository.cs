
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> GetAllIncludedAsync()
        {
            return await _dbSet.Include(book => book.BookCategories).ToListAsync();
        }

        public async Task<Book?> GetByIdIncludedAsync(int id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _context.Database.BeginTransactionAsync();

            try
            {
                await _dbSet.Where(x => x.Id == id).Include(book => book.BookCategories).FirstOrDefaultAsync();

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return entity;
        }
    }
}