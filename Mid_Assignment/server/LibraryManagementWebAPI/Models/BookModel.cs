using System.ComponentModel.DataAnnotations;
using LibraryManagement.Data.Entities;

namespace LibraryManagementWebAPI.Models
{
    public class BookModel : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
    }
}