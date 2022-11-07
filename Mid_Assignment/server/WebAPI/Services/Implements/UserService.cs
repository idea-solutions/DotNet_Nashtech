using Data.Repositories;
using WebAPI.Models;
using WebAPI.Models.DTOs.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse?> Authenticate(CreateUserRequest requestModel)
        {
            var user = await _userRepository
            .GetSingleAsync(user => user.Username == requestModel.Username &&
                                    user.Password == requestModel.Password);
            if (user == null) return null;

            // TODO: Token

            return new CreateUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString(),
                // TODO: token
            };
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Role = user.Role
            };
        }
    }
}