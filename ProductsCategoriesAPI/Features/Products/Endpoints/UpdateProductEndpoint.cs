using FastEndpoints;
using ProductsCategoriesAPI.Features.Products.Models;
using ProductsCategoriesAPI.Helpers.Extensions;
using ProductsCategoriesAPI.Helpers;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Products.Endpoints
{
    public class UpdateProductEndpoint :  Endpoint<ProductRequest, ProductResponse>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductEndpoint(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Put("/api/products/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
        {
            var productId = Route<Guid>("id");
            var product = await _repository.GetByIdAsync(productId);
            if (product == null)
            {
                await SendNotFoundAsync();
                return;
            }

            // Update entity with request data
            product.Name = req.Name;
            product.Description = req.Description;
            product.Price = req.Price;
            product.CategoryId = req.CategoryId;
            product.Status = Enum.Parse<ProductStatus>(req.Status, true);
            product.StockQuantity = req.StockQuantity;
            product.ImageUrl = req.ImageUrl;
            product.UpdatedDate = DateTime.UtcNow;

            _repository.Update(product);
            await _repository.SaveChangesAsync();

            // Map to response
            var response = product.ToResponse("Category Placeholder"); // Replace "Category Placeholder" with actual lookup if necessary
            await SendAsync(response);
        }
    }
}
