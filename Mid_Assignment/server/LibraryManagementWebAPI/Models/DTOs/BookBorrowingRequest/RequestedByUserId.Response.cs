using LibraryManagementWebAPI.Models.DTOs.User;

namespace LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest
{
    public class RequestedByUserIdResponse
    {
        public RequestedByUserIdResponse(LibraryManagement.Data.Entities.BookBorrowingRequest request)
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
                    Role = request.StatusUpdateBy.Role.ToString(),
                    Username = request.StatusUpdateBy.Username
                };
            }
        }
        public int Id { get; set; }
        public string Status { get; set; }
        public GetUserResponse RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }

        //TODO : change name
        public GetUserResponse? StatusUpdateByUserId { get; set; }
        public List<BookModel> Books { get; set; }
    }
}