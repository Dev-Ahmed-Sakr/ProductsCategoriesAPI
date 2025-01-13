using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ProductsCategoryAccess.Entities;
using ProductsCategoryAccess.Repositories;
using ProductsCategoryService.Models;
using ProductsCategoryService.Services;

namespace ProductsCategoriesAPI.Features.Categories.Endpoints
{
    public class GetAllCategoriesEndpoint : EndpointWithoutRequest<List<CategoryResponse>>
    {
        
        private readonly ICategoryService _categoryService;
        public GetAllCategoriesEndpoint(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override void Configure()
        {
            Get("/api/Categories");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var categories = await _categoryService.GetCategoriesAsync();
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
