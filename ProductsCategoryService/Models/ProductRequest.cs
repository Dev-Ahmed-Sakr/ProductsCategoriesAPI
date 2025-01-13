namespace ProductsCategoryService.Models
{
    public class ProductRequest
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public int Status { get; set; } //= "Active"; // "Active", "Inactive", "Discontinued"
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
    }
}
