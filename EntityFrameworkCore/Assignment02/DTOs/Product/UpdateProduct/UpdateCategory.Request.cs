using System.ComponentModel.DataAnnotations;

namespace Assignment02.Models
{
    public class UpdateProductRequest
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Manufacture { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}