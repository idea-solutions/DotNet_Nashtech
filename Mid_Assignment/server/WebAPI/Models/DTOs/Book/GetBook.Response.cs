namespace WebAPI.Models.DTOs.Book
{
    public class GetBookResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public List<CategoryModel>? Categories { get; set; }
    }
}