using FastEndpoints;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints;

public class DeleteCategoryEndpoint : EndpointWithoutRequest
{
    private readonly IRepository<Category> _repository;
    public DeleteCategoryEndpoint(IRepository<Category> repository)
    {
        _repository = repository;
    }
    /// <summary>
    /// Deletes a Category by its ID.
    /// </summary>
    /// <param name="id">The unique identifier (GUID) of the Category to delete.</param>
    public override void Configure()
    {
        Delete("/api/Categories/{id:guid}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var category = await _repository.GetByIdAsync(id);
        if (category is null)
        {
            await SendNotFoundAsync();
        }

        _repository.Delete(category);
        await _repository.SaveChangesAsync();
        await SendNoContentAsync();
    }
}