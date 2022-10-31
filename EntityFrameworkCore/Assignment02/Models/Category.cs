namespace Assignment02.Models
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}