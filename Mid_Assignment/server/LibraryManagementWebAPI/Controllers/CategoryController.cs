using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebAPI.Models.DTOs.Category;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var entities = await _categoryService.GetAllAsync();

                return new JsonResult(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}", Name = "GetByCategoryIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _categoryService.GetByIdAsync(id);

                if (entity == null) return NotFound();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest requestModel)
        {
            try
            {
                var result = await _categoryService.CreateAsync(requestModel);

                if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest requestModel)
        {

            // TODO: Check Exist
            var entity = await _categoryService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            try
            {
                var result = await _categoryService.UpdateAsync(requestModel);

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
            var entity = await _categoryService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            try
            {
                var result = await _categoryService.DeleteAsync(id);

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