namespace ProductsCategoryService.Models
{
    public class CategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int Status { get; set; }
    }
}
