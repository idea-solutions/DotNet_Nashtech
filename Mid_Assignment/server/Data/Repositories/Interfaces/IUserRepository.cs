using System.Linq.Expressions;
using Data.Entities;

namespace Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetSingleAsync(Expression<Func<User, bool>> predicate);
    }
}