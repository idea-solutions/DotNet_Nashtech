namespace Assignment02.Models
{
    public class Category : BaseEntity<int>
    {
        // public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}