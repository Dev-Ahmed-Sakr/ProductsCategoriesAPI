using FastEndpoints;
using ProductsCategoriesAPI.Features.Categories.Models;
using ProductsCategoriesAPI.Helpers.Extensions;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class CreateCategoryEndpoint : Endpoint<CategoryRequest,CategoryResponse>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryEndpoint(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Post("/api/Categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CategoryRequest req, CancellationToken ct)
        {
            var category = req.ToEntity();
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            var response = category.ToResponse("Parent Category");
            await SendAsync(response, 201);
        }
    }
}
