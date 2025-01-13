using FastEndpoints;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Products.Endpoints;

public class UpdateProductEndpoint : Endpoint<ProductRequest, ProductResponse>
{
    private readonly IProductService _productService;

    public UpdateProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Put("/api/products/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        var productId = Route<Guid>("id");
        var product = await _productService.GetProductAsync(productId);
        if (product == null)
        {
            await SendNotFoundAsync();
            return;
        }
        await SendAsync(product, statusCode: 200, ct);
    }
}
