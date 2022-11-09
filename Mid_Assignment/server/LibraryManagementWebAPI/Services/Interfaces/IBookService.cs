using LibraryManagementWebAPI.Models;
using LibraryManagementWebAPI.Models.DTOs.Book;

namespace LibraryManagementWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<GetBookResponse>> GetAllAsync();
        Task<GetBookResponse?> GetByIdAsync(int id);
        Task<CreateBookResponse?> CreateAsync(CreateBookRequest requestModel);
        Task<UpdateBookResponse?> UpdateAsync(UpdateBookRequest requestModel);
        Task<bool> DeleteAsync(int id);
    }
}