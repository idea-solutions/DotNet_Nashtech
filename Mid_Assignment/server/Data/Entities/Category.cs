using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Category : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}