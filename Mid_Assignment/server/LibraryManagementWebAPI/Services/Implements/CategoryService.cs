using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Repositories;
using LibraryManagementWebAPI.Models.DTOs.Category;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            _categoryRepository = repository;
        }

        public async Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest requestModel)
        {
            var newCategory = new Category
            {
                Name = requestModel.Name
            };

            var createdCategory = await _categoryRepository.CreateAsync(newCategory);

            return new CreateCategoryResponse
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(category => category.Id == id);

            if (category == null) return false;

            await _categoryRepository.DeleteAsync(category);

            return true;
        }

        public async Task<IEnumerable<GetCategoryResponse>> GetAllAsync()
        {
            var data = await _categoryRepository.GetAllAsync();

            return data.Select(category => new GetCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        public async Task<GetCategoryResponse?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(category => category.Id == id);

            if (category == null) return null;

            return new GetCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<UpdateCategoryResponse?> UpdateAsync(UpdateCategoryRequest requestModel)
        {
            var category = await _categoryRepository.GetByIdAsync(category => category.Id == requestModel.Id);

            if (category == null) return null;

            category.Name = requestModel.Name;

            var updatedCategory = await _categoryRepository.UpdateAsync(category);

            return new UpdateCategoryResponse
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name
            };
        }
    }
}