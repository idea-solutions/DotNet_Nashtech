using LibraryManagementWebAPI.Models;
using LibraryManagementWebAPI.Models.DTOs.User;

namespace LibraryManagementWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> GetByIdAsync(int id);
        Task<CreateUserResponse?> Authenticate(CreateUserRequest requestModel);
    }
}