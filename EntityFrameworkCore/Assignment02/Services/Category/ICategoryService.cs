using Assignment02.Models;

namespace Assignment02.Services;

public interface ICategoryService
{
    AddCategoryResponse? Create(AddCategoryRequest createModel);
}