using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs.Book
{
    public class CreateBookRequest
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        [Required]
        public List<int>? CategoryIds { get; set; }
    }
}