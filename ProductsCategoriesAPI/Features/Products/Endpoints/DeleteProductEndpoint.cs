using FastEndpoints;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Products.Endpoints
{
    public class DeleteProductEndpoint : EndpointWithoutRequest
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductEndpoint(IRepository<Product> repository)
        {
            _repository = repository;
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
            var product = await _repository.GetByIdAsync(productId);
            if (product == null)
            {
                await SendNotFoundAsync();
                return;
            }

            _repository.Delete(product);
            await _repository.SaveChangesAsync();

            await SendNoContentAsync();
        }
    }
}
