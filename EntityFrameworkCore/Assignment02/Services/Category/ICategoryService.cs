using Assignment02.Models;

namespace Assignment02.Services;

public interface ICategoryService
{
    AddCategoryResponse? Create(AddCategoryRequest createModel);
    IEnumerable<GetCategoryResponse>? GetAll();
    GetCategoryResponse? GetById(int id);
    UpdateCategoryResponse? Update(int id, UpdateCategoryRequest requestModel);
    bool Delete(int id);
}