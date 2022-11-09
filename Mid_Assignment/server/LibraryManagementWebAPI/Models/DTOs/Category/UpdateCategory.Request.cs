using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebAPI.Models.DTOs.Category
{
    public class UpdateCategoryRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}