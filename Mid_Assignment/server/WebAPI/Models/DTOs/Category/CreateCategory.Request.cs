using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string? Name { get; set; }
    }
}