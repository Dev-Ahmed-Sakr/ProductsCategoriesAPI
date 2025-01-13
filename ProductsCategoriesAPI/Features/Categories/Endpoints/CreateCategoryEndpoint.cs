using FastEndpoints;
using ProductsCategoryService.Helpers.Extensions;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class CreateCategoryEndpoint : Endpoint<CategoryRequest, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryEndpoint(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override void Configure()
        {
            Post("/api/Categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CategoryRequest req, CancellationToken ct)
        {
            try
            {
                var res = await _categoryService.CreateCategoryAsync(req);
                await SendAsync(res, 201);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
