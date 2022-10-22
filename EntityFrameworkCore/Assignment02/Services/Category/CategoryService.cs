using Assignment02.Models;
using Assignment02.Repositories;

namespace Assignment02.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public AddCategoryResponse? Create(AddCategoryRequest createModel)
    {
        using (var transaction = _categoryRepository.EntityDbTransaction())
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = createModel.CategoryName
                };

                var category = _categoryRepository.Create(newCategory);

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return new AddCategoryResponse
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                };
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }

    }
}