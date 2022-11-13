using LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest;

namespace LibraryManagementWebAPI.Services.Interfaces
{
    public interface IBookBorrowingRequestService
    {
        Task<IEnumerable<GetBookBorrowingRequestResponse>> GetAllAsync();
        Task<GetBookBorrowingRequestResponse?> GetByIdAsync(int id);
        Task<CreateBookBorrowingRequestResponse?> CreateAsync(CreateBookBorrowingRequestRequest requestModel);
        Task<StatusUpdateResponse?> ApproveAsync(StatusUpdateRequest requestModel);
        Task<string> CheckRequestLimit(CreateBookBorrowingRequestRequest request);
    }
}