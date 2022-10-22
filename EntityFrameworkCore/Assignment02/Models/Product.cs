using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment02.Models
{
    public class Product : BaseEntity<int>
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // [Column("ProductId")]
        // public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacture { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

