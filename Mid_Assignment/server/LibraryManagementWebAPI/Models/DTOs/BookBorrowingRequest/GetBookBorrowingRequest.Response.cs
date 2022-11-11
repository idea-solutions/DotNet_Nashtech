using LibraryManagementWebAPI.Models.DTOs.User;

namespace LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest
{
    public class GetBookBorrowingRequestResponse
    {
        public GetBookBorrowingRequestResponse(LibraryManagement.Data.Entities.BookBorrowingRequest request)
        {
            Id = request.Id;
            Status = request.Status.ToString();
            DateRequested = request.DateRequested;
            RequestedBy = new GetUserResponse
            {
                Id = request.RequestedBy.Id,
                Username = request.RequestedBy.Username,
                Role = request.RequestedBy.Role.ToString(),
            };

            DateUpdated = request.DateUpdated;

            Books = request.Books.Select(book => new BookModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Summary = book.Summary
            }).ToList();

            if (request.StatusUpdateByUserId != null)
            {
                StatusUpdateByUserId = new GetUserResponse
                {
                    Id = request.StatusUpdateBy.Id,
                    Username = request.StatusUpdateBy.Username,
                    Role = request.StatusUpdateBy.Role.ToString(),
                };
            }
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public GetUserResponse? RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }
        public GetUserResponse? StatusUpdateByUserId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<BookModel>? Books { get; set; }
    }
}