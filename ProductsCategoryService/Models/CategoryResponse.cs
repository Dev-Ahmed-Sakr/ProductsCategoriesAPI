namespace ProductsCategoryService.Models
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ParentCategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string StatusName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
