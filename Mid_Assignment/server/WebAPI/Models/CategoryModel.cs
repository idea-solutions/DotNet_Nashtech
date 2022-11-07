using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace WebAPI.Models
{
    public class CategoryModel : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
    }
}