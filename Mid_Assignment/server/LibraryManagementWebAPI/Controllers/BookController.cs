using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebAPI.Models.DTOs.Book;
using LibraryManagementWebAPI.Services.Interfaces;
using Common.Enums;
using LibraryManagementWebAPI.Attributes;

namespace LibraryManagementWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILoggerManager _logger;
        public BookController(IBookService bookService, ILoggerManager logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _bookService.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("{id}", Name = "GetByBookIdAsync")]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _bookService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookRequest requestModel)
        {
            var result = await _bookService.CreateAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

            return Ok(result);
        }

        [HttpPut]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookRequest requestModel)
        {

            var entity = await _bookService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            var result = await _bookService.UpdateAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while updating entity!");

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _bookService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            var result = await _bookService.DeleteAsync(id);

            if (!result) return StatusCode(500, "Something went wrong while delete entity!");

            return Ok();
        }
    }
}