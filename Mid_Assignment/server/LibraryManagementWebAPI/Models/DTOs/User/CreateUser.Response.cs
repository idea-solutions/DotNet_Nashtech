namespace LibraryManagementWebAPI.Models.DTOs.User
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}