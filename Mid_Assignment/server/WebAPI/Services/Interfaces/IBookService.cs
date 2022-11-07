using WebAPI.Models;
using WebAPI.Models.DTOs.Book;

namespace WebAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<GetBookResponse>> GetAllAsync();
        Task<GetBookResponse?> GetByIdAsync(int id);
        Task<ServiceResponse<CreateBookResponse?>> CreateAsync(CreateBookRequest requestModel);
        Task<UpdateBookResponse?> UpdateAsync(UpdateBookRequest requestModel);
        Task<bool?> DeleteAsync(int id);

        // Task<ServiceResponse<List<Book>>> GetBooksByCategory(string categoryUrl);
    }
}