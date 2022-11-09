using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebAPI.Models.DTOs.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string? Name { get; set; }
    }
}