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

        public Task<CreateUserResponse?> Authenticate(CreateUserRequest requestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(user => user.Id == id);

            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Role = user.Role
            };
        }
    }
}