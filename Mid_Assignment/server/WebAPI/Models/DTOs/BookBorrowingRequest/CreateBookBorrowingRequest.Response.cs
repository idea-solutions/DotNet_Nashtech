namespace WebAPI.Models.DTOs.BookBorrowingRequest
{
    public class CreateBookBorrowingRequestResponse
    {
        public CreateBookBorrowingRequestResponse(Data.Entities.BookBorrowingRequest request)
        {
            Id = request.Id;
            Status = request.Status.ToString();
            RequestedByUserId = request.RequestedByUserId;
            DateRequested = request.DateRequested;

            Books = request.Books.Select(book => new BookModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Summary = book.Summary

            }).ToList();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public int RequestedByUserId { get; set; }
        public DateTime DateRequested { get; set; }
        public List<BookModel> Books { get; set; }
    }
}