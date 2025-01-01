using FastEndpoints;
using ProductsCategoriesAPI.Features.Categories.Models;
using ProductsCategoriesAPI.Helpers;
using ProductsCategoriesAPI.Helpers.Extensions;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class UpdateCategoryEndpoint : Endpoint<CategoryRequest,CategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        public UpdateCategoryEndpoint(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Put("/api/Categories/{id:guid}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CategoryRequest req, CancellationToken ct)
        {
            var categoryId = Route<Guid>("id");
            var category = await _repository.GetByIdAsync(categoryId);
            if (category == null)
            {
                await SendNotFoundAsync();
                return;
            }
            category.Name = req.Name;
            category.Description = req.Description;
            category.ParentCategoryId = req.ParentCategoryId;
            _repository.Update(category);
            await _repository.SaveChangesAsync();

            var response = category.ToResponse("Parent Category");
            await SendAsync(response);
        }
    }

}

