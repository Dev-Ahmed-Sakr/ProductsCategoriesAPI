using ProductsCategoryService.Models;

namespace ProductsCategoryService.Services;

public interface IProductService
{
    Task<ProductResponse> CreateProductAsync(ProductRequest Product);
    Task<ProductResponse> GetProductAsync(Guid id);
    Task<IEnumerable<ProductResponse>> GetProductsAsync();
    Task<ProductResponse> UpdateProductAsync(ProductRequest Product);
    Task DeleteProductAsync(Guid id);
}
