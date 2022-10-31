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

    public bool Delete(int id)
    {
        using (var transaction = _categoryRepository.EntityDbTransaction())
        {
            try
            {
                var category = _categoryRepository.GetById(c => c.Id == id);

                if (category == null)
                {
                    return false;
                }

                _categoryRepository.Delete(category);

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();

                return false;
            }
        }
    }

    public IEnumerable<GetCategoryResponse>? GetAll()
    {
        using (var transaction = _categoryRepository.EntityDbTransaction())
        {
            try
            {
                var listCategories = _categoryRepository.GetAll().Select(c => new GetCategoryResponse
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName
                });

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return listCategories;
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }

    public GetCategoryResponse? GetById(int id)
    {
        using (var transaction = _categoryRepository.EntityDbTransaction())
        {
            try
            {
                var category = _categoryRepository.GetById(c => c.Id == id);

                if (category == null)
                {
                    return null;
                }

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return new GetCategoryResponse
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

    public UpdateCategoryResponse? Update(int id, UpdateCategoryRequest requestModel)
    {
        using (var transaction = _categoryRepository.EntityDbTransaction())
        {
            try
            {
                var category = _categoryRepository.GetById(c => c.Id == id);

                if (category == null)
                {
                    return null;
                }

                category.CategoryName = requestModel.CategoryName;

                var updatedCategory = _categoryRepository.Update(category);

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return new UpdateCategoryResponse
                {
                    CategoryId = updatedCategory.Id,
                    CategoryName = updatedCategory.CategoryName
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