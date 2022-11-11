using LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest;
using LibraryManagementWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/book-borrowing-requests")]
    public class BookBorrowingRequestController : ControllerBase
    {
        private readonly IBookBorrowingRequestService _bookBorrowingRequestService;

        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestService)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _bookBorrowingRequestService.GetAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _bookBorrowingRequestService.GetByIdAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookBorrowingRequestRequest requestModel)
        {
            try
            {
                var limitCheckMessage =
                    await _bookBorrowingRequestService.CheckRequestLimit(requestModel);

                if (!string.IsNullOrEmpty(limitCheckMessage))
                {
                    return BadRequest(limitCheckMessage);
                }

                var result = await _bookBorrowingRequestService.CreateAsync(requestModel);

                if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

                return CreatedAtRoute(new { id = result.Id.ToString() }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("Approve")]
        public async Task<IActionResult> Approve([FromBody] StatusUpdateRequest requestModel)
        {

            var entity = await _bookBorrowingRequestService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            try
            {
                var result = await _bookBorrowingRequestService.ApproveAsync(requestModel);

                if (result == null) return StatusCode(500, "Something went wrong while updating entity!");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}