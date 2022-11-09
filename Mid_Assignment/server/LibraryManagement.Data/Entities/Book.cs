using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Data.Entities
{
    public class Book : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        // public ICollection<BookCategory>? BookCategories { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<BookBorrowingRequest>? BookBorrowingRequest { get; set; }
        // public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }
    }
}