using FastEndpoints;
using ProductsCategoriesAPI.Features.Categories.Models;
using ProductsCategoriesAPI.Features.Products.Models;
using ProductsCategoriesAPI.Interfaces;
using ProductsCategoriesAPI.Models;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class GetAllCategoriesEndpoint : EndpointWithoutRequest<List<CategoryResponse>>
    {
        private readonly IRepository<Category> _repository;

        public GetAllCategoriesEndpoint(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public override void Configure()
        {
            Get("/api/Categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var categories = await _repository.GetAllAsync();
            var response  = categories.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
            await SendAsync(response);
        }
    }
}
