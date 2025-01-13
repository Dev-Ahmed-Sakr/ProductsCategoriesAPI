using FastEndpoints;
using ProductsCategoryAccess.Entities;
using ProductsCategoryAccess.Repositories;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints;

public class DeleteCategoryEndpoint : EndpointWithoutRequest
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryEndpoint(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    /// <summary>
    /// Deletes a Category by its ID.
    /// </summary>
    /// <param name="id">The unique identifier (GUID) of the Category to delete.</param>
    public override void Configure()
    {
        Delete("/api/Categories/{id:guid}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Deletes a category by ID";
            s.Description = "Provide the category ID in the URL path to delete the corresponding category.";
            s.Response(204, "The category was successfully deleted.");
            s.Response(404, "The category with the given ID was not found.");
        });
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var category = await _categoryService.GetCategoryAsync(id);
        if (category is null)
        {
            await SendNotFoundAsync();
        }

        await _categoryService.DeleteCategoryAsync(category.Id);
        await SendNoContentAsync();
    }
}