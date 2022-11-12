using Common.Enums;
using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Repositories;
using LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Services.Implements
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookBorrowingRequestRepository _bookBorrowingRequestRepository;

        public BookBorrowingRequestService(IBookRepository bookRepository, IBookBorrowingRequestRepository bookBorrowingRequestRepository)
        {
            _bookRepository = bookRepository;
            _bookBorrowingRequestRepository = bookBorrowingRequestRepository;
        }

        public async Task<StatusUpdateResponse?> ApproveAsync(StatusUpdateRequest requestModel)
        {
            var bookBorrowingRequest =
                await _bookBorrowingRequestRepository.GetByIdIncludedAsync(bookBorrowRequest => bookBorrowRequest.Id == requestModel.Id);

            if (bookBorrowingRequest == null) return null;

            bookBorrowingRequest.Status = requestModel.IsApproved
                                                ? RequestStatusEnum.Approved
                                                : RequestStatusEnum.Rejected;
            bookBorrowingRequest.StatusUpdateByUserId = requestModel.StatusUpdateBy.Id;

            var updatedBorrowRequest = await _bookBorrowingRequestRepository.UpdateAsync(bookBorrowingRequest);

            return new StatusUpdateResponse(updatedBorrowRequest);
        }

        public async Task<string> CheckRequestLimit(CreateBookBorrowingRequestRequest request)
        {
            if (request.RequestedBy == null)
            {
                return "Request has no requester!";
            }

            if (request.BookIds.Count < 1)
            {
                return "Minimum books per request not reached!";
            }

            if (request.BookIds.Count > 5)
            {
                return "Books per request limit exceeded!";
            }

            var currentMonth = DateTime.UtcNow.Month;

            var bookRequestsThisMonth = await _bookBorrowingRequestRepository
                .GetAllAsync(br =>
                    br.RequestedByUserId == request.RequestedBy.Id &&
                    br.DateRequested.Month == currentMonth);

            if (bookRequestsThisMonth.Count() >= 3)
            {
                return "Requests per month limit exceeded!";
            }

            return string.Empty;
        }

        public async Task<CreateBookBorrowingRequestResponse?> CreateAsync(CreateBookBorrowingRequestRequest requestModel)
        {
            var bookIds = requestModel.BookIds.Distinct();

            var books = await _bookRepository.GetAllAsync(book => bookIds.Contains(book.Id))
                                    as List<Book>;

            if (books == null ||
                books.Count != bookIds.Count())
                return null;

            var newbookBorrowingRequest = new BookBorrowingRequest
            {
                Status = RequestStatusEnum.Waiting,
                Books = books,
                RequestedByUserId = requestModel.RequestedBy.Id,
                DateRequested = DateTime.UtcNow
            };

            var createdBorrowRequest = await _bookBorrowingRequestRepository.CreateAsync(newbookBorrowingRequest);

            return new CreateBookBorrowingRequestResponse(createdBorrowRequest);
        }

        public async Task<IEnumerable<GetBookBorrowingRequestResponse>> GetAllAsync()
        {
            var data = await _bookBorrowingRequestRepository.GetAllIncludedAsync();

            return data.Select(bookBorrowingRequest => new GetBookBorrowingRequestResponse(bookBorrowingRequest));
        }

        public async Task<GetBookBorrowingRequestResponse?> GetByIdAsync(int id)
        {
            var data = await _bookBorrowingRequestRepository.GetByIdIncludedAsync(i => i.Id == id);

            if (data == null) return null;

            return new GetBookBorrowingRequestResponse(data);
        }
    }
}