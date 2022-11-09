using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebAPI.Models
{
    public class CategoryModel
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}