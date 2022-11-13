using LibraryManagementWebAPI.Models.DTOs.User;

namespace LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest
{
    public class StatusUpdateResponse
    {
        public StatusUpdateResponse(LibraryManagement.Data.Entities.BookBorrowingRequest request)
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
            StatusUpdateBy = request.StatusUpdateBy != null
                ? new GetUserResponse
                {
                    Id = request.StatusUpdateBy.Id,
                    Username = request.StatusUpdateBy.Username,
                    Role = request.StatusUpdateBy.Role.ToString(),
                }
                : null;
            Books = request.Books.Select(book => new BookModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Summary = book.Summary,
            }).ToList();
        }
        public int Id { get; set; }
        public string Status { get; set; }
        public GetUserResponse RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }
        public GetUserResponse? StatusUpdateBy { get; set; }
        public List<BookModel> Books { get; set; }
    }
}