using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Jwt;
using LibraryManagementWebAPI.Models.DTOs.User;
using LibraryManagementWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] CreateUserRequest requestModel)
        {
            try
            {
                var user = await _userService.LoginUser(requestModel);

                if (user == null)
                    return BadRequest("Username or password is incorrect!");

                var claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.Username)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstant.Key));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expired = DateTime.UtcNow.AddMinutes(JwtConstant.ExpiredTime);

                var token = new JwtSecurityToken(JwtConstant.Issuer,
                                                JwtConstant.Audience,
                                                claims, expires: expired,
                                                signingCredentials: signIn);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new CreateUserResponse
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role.ToString(),
                    Token = tokenString
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}