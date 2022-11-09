using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Repositories;
using LibraryManagementWebAPI.Models;
using LibraryManagementWebAPI.Models.DTOs.Book;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateBookResponse?> CreateAsync(CreateBookRequest requestModel)
        {
            var categoryIds = requestModel.CategoryIds.Distinct();

            var categories = await _categoryRepository.GetAllAsync(category => categoryIds.Contains(category.Id))
                                            as List<Category>;

            if (categories == null) return null;

            var newBook = new Book
            {
                Name = requestModel.Name,
                Author = requestModel.Author,
                Summary = requestModel.Summary,
                Categories = categories
            };

            var createdBook = await _bookRepository.CreateAsync(newBook);

            return new CreateBookResponse
            {
                Id = createdBook.Id,
                Name = createdBook.Name,
                Author = createdBook.Author,
                Summary = createdBook.Summary,
                Categories = createdBook.Categories
                    .Select(category => new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name
                    })
                    .ToList()
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdIncludedAsync(book => book.Id == id);

            if (book == null) return false;

            await _bookRepository.DeleteAsync(book);

            return true;
        }

        public async Task<IEnumerable<GetBookResponse>> GetAllAsync()
        {

            var data = (await _bookRepository.GetAllIncludedAsync());

            return data.Select(book => new GetBookResponse
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Summary = book.Summary,
                Categories = book.Categories
                        .Select(category => new CategoryModel
                        {
                            Id = category.Id,
                            Name = category.Name
                        })
                        .ToList()
            });
        }

        public async Task<GetBookResponse?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdIncludedAsync(book => book.Id == id);

            if (book == null) return null;

            return new GetBookResponse
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Summary = book.Summary,
                Categories = book.Categories
                    .Select(category => new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name
                    })
                    .ToList()
            };
        }

        public async Task<UpdateBookResponse?> UpdateAsync(UpdateBookRequest requestModel)
        {
            var categoryIds = requestModel.CategoryIds.Distinct();

            var categories = await _categoryRepository.GetAllAsync(category => categoryIds.Contains(category.Id))
                                            as List<Category>;

            if (categories == null) return null;

            var book = await _bookRepository.GetByIdIncludedAsync(book => book.Id == requestModel.Id);

            if (book == null) return null;

            book.Name = requestModel.Name;
            book.Author = requestModel.Author;
            book.Summary = requestModel.Summary;
            book.Categories = categories;

            var updatedBook = await _bookRepository.UpdateAsync(book);

            return new UpdateBookResponse
            {
                Id = updatedBook.Id,
                Name = updatedBook.Name,
                Author = updatedBook.Author,
                Summary = updatedBook.Summary,
                Categories = updatedBook.Categories
                    .Select(category => new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name
                    })
                    .ToList()
            };
        }
    }
}