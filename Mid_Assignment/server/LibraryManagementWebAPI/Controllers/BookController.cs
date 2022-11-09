using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebAPI.Models.DTOs.Book;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var entities = await _bookService.GetAllAsync();

                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}", Name = "GetByBookIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _bookService.GetByIdAsync(id);

                if (entity == null) return NotFound();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookRequest requestModel)
        {
            try
            {
                var result = await _bookService.CreateAsync(requestModel);

                if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

                return CreatedAtRoute("Create", new { id = result.Id.ToString() }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBookRequest requestModel)
        {

            // TODO: Check Exist
            var entity = await _bookService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            try
            {
                var result = await _bookService.UpdateAsync(requestModel);

                if (result == null) return StatusCode(500, "Something went wrong while updating entity!");

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            // TODO: Check Exist
            var entity = await _bookService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            try
            {
                var result = await _bookService.DeleteAsync(id);

                if (!result) return StatusCode(500, "Something went wrong while delete entity!");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}