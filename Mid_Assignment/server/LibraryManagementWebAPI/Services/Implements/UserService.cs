using LibraryManagement.Data.Repositories;
using LibraryManagementWebAPI.Models;
using LibraryManagementWebAPI.Models.DTOs.User;
using LibraryManagementWebAPI.Services.Interfaces;

namespace LibraryManagementWebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse?> LoginUser(CreateUserRequest requestModel)
        {
            var user = await _userRepository
                .GetSingleAsync(user => user.Username == requestModel.Username &&
                                    user.Password == requestModel.Password);

            return new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString(),
            };
        }

        public async Task<UserModel?> GetByIdAsync(int? id)
        {
            var user = await _userRepository.GetSingleAsync(user => user.Id == id);

            if (user == null || id == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Role = user.Role
            };
        }
    }
}