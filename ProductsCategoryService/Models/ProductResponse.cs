namespace ProductsCategoryService.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; } 
        public int Status { get; set; }  // "Active", "Inactive", "Discontinued"
        public string StatusName { get; set; }  // "Active", "Inactive", "Discontinued"

        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
