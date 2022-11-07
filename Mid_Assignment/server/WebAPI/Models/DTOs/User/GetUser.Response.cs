namespace WebAPI.Models.DTOs.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
    }
}