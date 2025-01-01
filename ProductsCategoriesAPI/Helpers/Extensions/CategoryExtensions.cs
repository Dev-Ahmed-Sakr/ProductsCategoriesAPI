using ProductsCategoriesAPI.Features.Categories.Models;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Helpers.Extensions
{
    public static class CategoryExtensions
    {
        public static Category ToEntity(this CategoryRequest req)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Description = req.Description,
                ParentCategoryId = req.ParentCategoryId,
                Status = Enum.Parse<CategoryStatus>(req.Status, true),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        public static CategoryResponse ToResponse(this Category category, string parentCategoryName)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ParentCategoryName = parentCategoryName,
                Status = category.Status.ToString(),
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate
            };
        }
    }
}
