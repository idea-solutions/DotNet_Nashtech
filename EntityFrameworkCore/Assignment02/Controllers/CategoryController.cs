using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
using Assignment02.Models;

namespace Assignment02.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public AddCategoryResponse? Add([FromBody] AddCategoryRequest modelRequest)
    {
        return _categoryService.Create(modelRequest);
    }
}