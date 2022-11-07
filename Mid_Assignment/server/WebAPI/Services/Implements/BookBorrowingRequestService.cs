using System.Linq.Expressions;
using Common.Enums;
using Data.Entities;
using Data.Repositories;
using WebAPI.Models.DTOs.BookBorrowingRequest;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implements
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

            bookBorrowingRequest.Status = requestModel.IsUpdated
                                                ? RequestStatusEnum.Approved
                                                : RequestStatusEnum.Rejected;
            bookBorrowingRequest.StatusUpdateByUserId = requestModel.StatusUpdateBy.Id;

            var updatedBorrowRequest = await _bookBorrowingRequestRepository.UpdateAsync(bookBorrowingRequest);

            return new StatusUpdateResponse(updatedBorrowRequest);
        }

        public Task<string> CheckRequestLimit(CreateBookBorrowingRequestRequest request)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<GetBookBorrowingRequestResponse>> GetAllAsync(RequestedByUserIdRequest requestModel)
        {
            Expression<Func<BookBorrowingRequest, bool>>? predicate = null;

            if (requestModel.RequestedByUserId.Role == RolesEnum.NormalUser)
            {
                predicate = br => br.RequestedBy.Id == requestModel.RequestedByUserId.Id;
            }
            var data = await _bookBorrowingRequestRepository.GetAllAsync(predicate);

            return data.Select(bookBorrowingRequest => new GetBookBorrowingRequestResponse(bookBorrowingRequest));
        }

        public async Task<GetBookBorrowingRequestResponse?> GetByIdAsync(RequestedByUserIdRequest request)
        {
            if (request.Id == null)
            {
                return null;
            }

            Expression<Func<BookBorrowingRequest, bool>>? predicate = bookBorrowingRequest => bookBorrowingRequest.Id == request.Id;

            if (request.RequestedByUserId.Role == RolesEnum.NormalUser)
            {
                predicate = br => (
                    br.RequestedBy.Id == request.RequestedByUserId.Id && br.Id == request.Id);
            }

            var bookBorrowingRequest = await _bookBorrowingRequestRepository.GetByIdIncludedAsync(predicate);

            if (bookBorrowingRequest == null) return null;

            return new GetBookBorrowingRequestResponse(bookBorrowingRequest);
        }
    }
}