using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebAPI.Models.DTOs.Category;
using LibraryManagementWebAPI.Services.Interfaces;
using LibraryManagementWebAPI.Attributes;
using Common.Enums;

namespace LibraryManagementWebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, ILoggerManager logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _categoryService.GetAllAsync();

            return new JsonResult(entities);
        }

        [HttpGet("{id}", Name = "GetByCategoryIdAsync")]
        [AuthorizeRoles(UserRoles.SuperUser, UserRoles.NormalUser)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest requestModel)
        {
            var result = await _categoryService.CreateAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while creating entity!");

            return new JsonResult(result);
        }

        [HttpPut]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest requestModel)
        {
            var entity = await _categoryService.GetByIdAsync(requestModel.Id);

            if (entity == null) return NotFound();

            var result = await _categoryService.UpdateAsync(requestModel);

            if (result == null) return StatusCode(500, "Something went wrong while updating entity!");

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRoles.SuperUser)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);

            if (entity == null) return NotFound();

            var result = await _categoryService.DeleteAsync(id);

            if (!result) return StatusCode(500, "Something went wrong while delete entity!");

            return Ok();
        }
    }
}