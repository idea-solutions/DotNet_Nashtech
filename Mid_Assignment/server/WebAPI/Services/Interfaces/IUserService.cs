using WebAPI.Models;
using WebAPI.Models.DTOs.User;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> GetByIdAsync(int id);
        Task<CreateUserResponse?> Authenticate(CreateUserRequest requestModel);
    }
}