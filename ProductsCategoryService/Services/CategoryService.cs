using Microsoft.EntityFrameworkCore;
using ProductsCategoriesAPI.Helpers;
using ProductsCategoryAccess.Entities;
using ProductsCategoryAccess.Repositories;
using ProductsCategoryService.Helpers.Extensions;
using ProductsCategoryService.Models;


namespace ProductsCategoryService.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IRepository<Category, Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CategoryResponse> CreateCategoryAsync(CategoryRequest model)
    {
        var category = new Category
        {
            Name = model.Name,
            Description = model.Description,
            CreatedDate = DateTime.UtcNow,
            ParentCategoryId = model.ParentCategoryId,
            Status = model.Status
        };
        var savedCategory = await _repository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();

        var response = new CategoryResponse
        {
            Id = savedCategory.Id,
            Name = savedCategory.Name,
            Description = savedCategory.Description,
            ParentCategoryId = savedCategory.ParentCategoryId,
            Status = savedCategory.Status,
            CreatedDate = savedCategory.CreatedDate,
            ParentCategoryName = savedCategory.ParentCategory?.Name,
            StatusName = ((CategoryStatus)savedCategory.Status).ToString()
        };
        return response;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
    {
        var res = _repository.GetAll();
        return await res.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ParentCategoryId = c.ParentCategoryId,
            Status = c.Status,
            CreatedDate = c.CreatedDate,
            StatusName = ((CategoryStatus)c.Status).ToString()
        }).ToListAsync();
    }

    public async Task<CategoryResponse> GetCategoryAsync(Guid id)
    {
        var res = await _repository.GetByIdAsync(id);
        return new CategoryResponse
        {
            Id = res.Id,
            Name = res.Name,
            Description = res.Description,
            ParentCategoryId = res.ParentCategoryId,
            Status = res.Status,
            StatusName = ((CategoryStatus)res.Status).ToString(),
            CreatedDate = res.CreatedDate,
            UpdatedDate = res.UpdatedDate
        };
    }

    public async Task<CategoryResponse> UpdateCategoryAsync(CategoryRequest category)
    {
        await _repository.UpdateAsync(new Category
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ParentCategoryId = category.ParentCategoryId,
            Status = category.Status,
        });
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description =
            category.Description,
            ParentCategoryId =
            category.ParentCategoryId,
            Status = category.Status
            
        };
    }
}
