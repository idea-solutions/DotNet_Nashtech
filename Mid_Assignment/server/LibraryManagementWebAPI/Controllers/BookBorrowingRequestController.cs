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
        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestService, IUserService userService)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
            _userService = userService;
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
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
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
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

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
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