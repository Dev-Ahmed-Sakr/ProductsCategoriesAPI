using ProductsCategoriesAPI.Features.Products.Models;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Helpers.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToEntity(this ProductRequest req)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                CategoryId = req.CategoryId,
                Status = Enum.Parse<ProductStatus>(req.Status, true),
                StockQuantity = req.StockQuantity,
                ImageUrl = req.ImageUrl
            };
        }

        public static ProductResponse ToResponse(this Product product)
        {
            // get category name from lookup by id
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category.Name, // put name here
                Status = product.Status.ToString(),
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
