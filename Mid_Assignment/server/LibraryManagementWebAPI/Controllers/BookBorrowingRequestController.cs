using Common.Enums;
using LibraryManagementWebAPI.Attributes;
using LibraryManagementWebAPI.Helpers;
using LibraryManagementWebAPI.Models;
using LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest;
using LibraryManagementWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/book-borrowing-requests")]
    public class BookBorrowingRequestController : ControllerBase
    {
        private readonly IBookBorrowingRequestService _bookBorrowingRequestService;
        private readonly IUserService _userService;
        private readonly ILoggerManager _logger;
        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestService, IUserService userService, ILoggerManager logger)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _bookBorrowingRequestService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookBorrowingRequestService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.NormalUser)]
        public async Task<IActionResult> Create([FromBody] CreateBookBorrowingRequestRequest requestModel)
        {
            var userId = this.GetCurrentLoginUserId();

            if (userId == null)
                return NotFound();

            var user = await _userService.GetByIdAsync(userId);

            requestModel.RequestedBy = new UserModel
            {
                Id = user.Id,
                Role = user.Role
            };

            var limitCheckMessage =
                    await _bookBorrowingRequestService.CheckRequestLimit(requestModel);

            if (!string.IsNullOrEmpty(limitCheckMessage))
            {
                return BadRequest(limitCheckMessage);
            }

            var result = await _bookBorrowingRequestService.CreateAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

            return Ok(result);
        }

        [HttpPost("Approve")]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> Approve([FromBody] StatusUpdateRequest requestModel)
        {

            var userId = this.GetCurrentLoginUserId();

            if (userId == null)
                return NotFound();

            var user = await _userService.GetByIdAsync(userId);

            requestModel.StatusUpdateBy = new UserModel
            {
                Id = user.Id,
                Role = user.Role
            };

            var entity = await _bookBorrowingRequestService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            var result = await _bookBorrowingRequestService.ApproveAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while updating entity!");

            return Ok(result);
        }
    }
}