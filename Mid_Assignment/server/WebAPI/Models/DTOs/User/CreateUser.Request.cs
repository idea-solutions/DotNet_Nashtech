using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs.User
{
    public class CreateUserRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}