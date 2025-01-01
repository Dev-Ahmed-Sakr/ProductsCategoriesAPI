namespace ProductsCategoriesAPI.Features.Products.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string Status { get; set; } = "Active"; // "Active", "Inactive", "Discontinued"
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
    }
}
