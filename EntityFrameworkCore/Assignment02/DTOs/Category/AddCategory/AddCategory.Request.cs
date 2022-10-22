using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models
{
    public class AddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}