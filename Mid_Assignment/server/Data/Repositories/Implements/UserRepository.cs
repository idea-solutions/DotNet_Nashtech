
using Data.Entities;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
    }
}