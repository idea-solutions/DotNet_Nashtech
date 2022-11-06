
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        private readonly DbSet<T> _dbSet;
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _context.Database.BeginTransactionAsync();

            try
            {
                await _dbSet.AddAsync(entity);

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _context.Database.BeginTransactionAsync();

            try
            {
                _dbSet.Remove(entity);

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _context.Database.BeginTransactionAsync();

            try
            {
                await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _context.Database.RollbackTransactionAsync();
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _context.Database.BeginTransactionAsync();

            try
            {
                _dbSet.Update(entity);

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