using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
using Assignment02.Models;

namespace Assignment02.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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

    [HttpGet]
    public IEnumerable<GetCategoryResponse>? GetAll()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id}", Name = "GetByCategoryId")]
    public GetCategoryResponse? GetById(int id)
    {
        return _categoryService.GetById(id);
    }

    [HttpPut("{id}", Name = "UpdateCategory")]
    public UpdateCategoryResponse? Update(int id, [FromBody] UpdateCategoryRequest updateModel)
    {
        return _categoryService.Update(id, updateModel);
    }

    [HttpDelete("{id}", Name = "DeleteCategory")]
    public bool Delete(int id)
    {
        return _categoryService.Delete(id);
    }
}