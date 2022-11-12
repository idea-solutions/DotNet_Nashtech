using System.Linq.Expressions;
using LibraryManagement.Data.Entities;

namespace LibraryManagement.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetSingleAsync(Expression<Func<User, bool>>? predicate = null);
    }
}