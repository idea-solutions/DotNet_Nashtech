namespace WebAPI.Models.DTOs.BookBorrowingRequest
{
    public class RequestedByUserIdRequest
    {
        public int? Id { get; set; }
        public UserModel? RequestedByUserId { get; set; }
    }
}