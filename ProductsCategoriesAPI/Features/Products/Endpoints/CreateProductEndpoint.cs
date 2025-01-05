using FastEndpoints;
using ProductsCategoriesAPI.Features.Products.Models;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Helpers;
using ProductsCategoriesAPI.Models;
using ProductsCategoriesAPI.Helpers.Extensions;

public class CreateProductEndpoint : Endpoint<ProductRequest, ProductResponse>
{
    private readonly IRepository<Product> _repository;

    public CreateProductEndpoint(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProductRequest req, CancellationToken ct)
    {
        // Map ProductRequest to Product entity
        var product = req.ToEntity();

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        // Map Product entity to ProductResponse
        var response = product.ToResponse();
        await SendAsync(response, 201);
    }
}
