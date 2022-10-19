namespace EntityFrameworkCore.Models
{
    public class GetAllStudentsResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
    }
}