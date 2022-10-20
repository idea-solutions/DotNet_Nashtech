namespace Assignment02.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;
    }
}