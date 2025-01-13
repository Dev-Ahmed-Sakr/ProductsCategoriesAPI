using ProductsCategoryService.Models;

namespace ProductsCategoryService.Services;

public interface ICategoryService
{
    Task<CategoryResponse> CreateCategoryAsync(CategoryRequest category);
    Task<CategoryResponse> GetCategoryAsync(Guid id);
    Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();
    Task<CategoryResponse> UpdateCategoryAsync(CategoryRequest category);
    Task DeleteCategoryAsync(Guid id);
}
