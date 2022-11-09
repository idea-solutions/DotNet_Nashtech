using LibraryManagement.Data.Entities;

namespace LibraryManagement.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryManagementContext context) : base(context)
        {

        }
    }
}