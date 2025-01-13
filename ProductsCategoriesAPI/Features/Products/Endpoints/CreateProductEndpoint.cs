using FastEndpoints;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

public class CreateProductEndpoint : Endpoint<ProductRequest, ProductResponse>
{
    private readonly IProductService _productService;

    public CreateProductEndpoint(IProductService productService)
    {
        _productService = productService;
    }

    public override void Configure()
    {
        Post("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {

        var savedProduct = await _productService.CreateProductAsync(req);

        await SendAsync(savedProduct, 201);
    }
}
