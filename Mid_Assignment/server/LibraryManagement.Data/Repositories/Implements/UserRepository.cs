using System.Linq.Expressions;
using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryManagementContext context) : base(context)
        {

        }

        public Task<User?> GetSingleAsync(Expression<Func<User, bool>>? predicate = null)
        {
            return predicate == null ? _dbSet.SingleOrDefaultAsync() : _dbSet.SingleOrDefaultAsync(predicate);
        }
    }
}