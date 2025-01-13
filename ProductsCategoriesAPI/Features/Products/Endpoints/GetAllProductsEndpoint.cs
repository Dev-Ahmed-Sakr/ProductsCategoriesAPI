using FastEndpoints;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

public class GetAllProductsEndpoint : EndpointWithoutRequest<List<ProductResponse>>
{
    private readonly IProductService _productService;

    public GetAllProductsEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Get("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = await _productService.GetProductsAsync();

        await SendAsync(products.ToList());
    }
}
