using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}