using FastEndpoints;
using ProductsCategoryAccess.Repositories;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Products.Endpoints
{
    public class DeleteProductEndpoint : EndpointWithoutRequest
    {

        private readonly IProductService _productService;

        public DeleteProductEndpoint(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the product to delete.</param>
        public override void Configure()
        {
            Delete("/api/products/{id:guid}");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Deletes a product by ID.";
                s.Description = "Provide the product ID in the URL path to delete the corresponding product.";
                s.Response(204, "The product was successfully deleted.");
                s.Response(404, "The product with the given ID was not found.");
            });
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var productId = Route<Guid>("id");
            var product = await _productService.GetProductAsync(productId);
            if (product == null)
            {
                await SendNotFoundAsync();
                return;
            }

            await _productService.DeleteProductAsync(product.Id);

            await SendNoContentAsync();
        }
    }
}
