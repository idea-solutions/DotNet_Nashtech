using WebAPI.Models.DTOs.BookBorrowingRequest;

namespace WebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        Task<IEnumerable<GetBookBorrowingRequestResponse>> GetAllAsync(RequestedByUserIdRequest requestModel);
        Task<GetBookBorrowingRequestResponse?> GetByIdAsync(RequestedByUserIdRequest request);
        Task<CreateBookBorrowingRequestResponse?> CreateAsync(CreateBookBorrowingRequestRequest requestModel);
        Task<StatusUpdateResponse?> ApproveAsync(StatusUpdateRequest requestModel);
        Task<string> CheckRequestLimit(CreateBookBorrowingRequestRequest request);
    }
}