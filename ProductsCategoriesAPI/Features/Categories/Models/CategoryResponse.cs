namespace ProductsCategoriesAPI.Features.Categories.Models
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ParentCategoryName { get; set; }
        public string Status { get; set; } = "Active"; // "Active", "Inactive"
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
