using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs.Category
{
    public class UpdateCategoryRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}