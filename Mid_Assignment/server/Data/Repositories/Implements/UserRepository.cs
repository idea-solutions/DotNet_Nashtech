
using System.Linq.Expressions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
        public async Task<User?> GetSingleAsync(Expression<Func<User, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
    }
}