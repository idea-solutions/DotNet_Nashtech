using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Data.Entities
{
    public class User : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Username { get; set; } = null;
        [Required]
        public string Password { get; set; }
        public RolesEnum Role { get; set; }
        public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
        public ICollection<BookBorrowingRequest>? ProcessedRequests { get; set; }
    }
}