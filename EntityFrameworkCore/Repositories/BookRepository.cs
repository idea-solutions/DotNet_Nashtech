using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public List<Book> GetAllBooks()
        {
            return _bookStoreContext.Books.ToList();
        }

        public void CreateBook(Book book)
        {
            _bookStoreContext.Books.Add(book);
            _bookStoreContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var bookTemp = _bookStoreContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();

            if (bookTemp != null)
            {
                bookTemp.Title = book.Title;
                _bookStoreContext.SaveChanges();
            }

            // cachs 2
            // _bookStoreContext.Books.Update(book);
        }

        // public void DeleteBook(int bookId)
        // {
        //     _bookStoreContext.Books.Where(x => x.BookId == bookId);
        // }
    }
}