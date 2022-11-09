using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebAPI.Models.DTOs.Book
{
    public class UpdateBookRequest
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public List<int>? CategoryIds { get; set; }
    }
}