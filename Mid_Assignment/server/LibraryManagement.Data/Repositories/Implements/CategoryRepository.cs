
using LibraryManagement.Data.Entities;

namespace LibraryManagement.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryManagementContext context) : base(context)
        {

        }
    }
}