
using Data.Entities;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context) : base(context)
        {

        }
    }
}