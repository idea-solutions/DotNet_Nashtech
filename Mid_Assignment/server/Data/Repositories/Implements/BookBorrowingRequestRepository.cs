
using Data.Entities;

namespace Data.Repositories
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(DataContext context) : base(context)
        {

        }
    }
}