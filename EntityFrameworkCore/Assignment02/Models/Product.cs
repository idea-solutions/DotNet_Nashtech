namespace Assignment02.Models
{
    public class Product
    {

        public Category Category { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}

