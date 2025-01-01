using FastEndpoints;
using ProductsCategoriesAPI.Features.Products.Models;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

public class GetAllProductsEndpoint : EndpointWithoutRequest<List<ProductResponse>>
{
    private readonly IRepository<Product> _repository;

    public GetAllProductsEndpoint(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = await _repository.GetAllAsync();

        // Map Product entities to ProductResponse DTOs
        var response = products.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryName = p.Name,
            Status = p.Status.ToString(),
            StockQuantity = p.StockQuantity,
            ImageUrl = p.ImageUrl
        }).ToList();

        await SendAsync(response);
    }
}
