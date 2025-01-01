namespace ProductsCategoriesAPI.Features.Categories.Models
{
    public class CategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string Status { get; set; } = "Active"; // "Active", "Inactive"
    }
}
