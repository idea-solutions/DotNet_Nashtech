
using Data.Entities;

namespace Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}