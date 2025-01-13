using FastEndpoints;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class UpdateCategoryEndpoint : Endpoint<CategoryRequest, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;
        public UpdateCategoryEndpoint(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public override void Configure()
        {
            Put("/api/Categories/{id:guid}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CategoryRequest req, CancellationToken ct)
        {
            var categoryId = Route<Guid>("id");
            var response = await _categoryService.GetCategoryAsync(categoryId);
            if (response == null)
            {
                await SendNotFoundAsync();
                return;
            }
            await SendAsync(response);
        }
    }

}

