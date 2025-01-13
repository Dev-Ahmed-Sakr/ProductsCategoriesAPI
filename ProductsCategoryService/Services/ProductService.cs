using Microsoft.EntityFrameworkCore;
using ProductsCategoriesAPI.Helpers;
using ProductsCategoryAccess.Entities;
using ProductsCategoryAccess.Repositories;
using ProductsCategoryService.Models;

namespace ProductsCategoryService.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IRepository<Product, Guid> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProductResponse> CreateProductAsync(ProductRequest model)
    {
        var Product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            CreatedDate = DateTime.UtcNow,
            Status = model.Status
        };
        var savedProduct = await _repository.AddAsync(Product);
        await _unitOfWork.SaveChangesAsync();

        var response = new ProductResponse
        {
            Id = savedProduct.Id,
            Name = savedProduct.Name,
            Description = savedProduct.Description,
            Status = savedProduct.Status,
            CreatedDate = savedProduct.CreatedDate,
            CategoryId = savedProduct.CategoryId,
            StatusName = ((ProductStatus)savedProduct.Status).ToString()
        };
        return response;
    }

    public async Task DeleteProductAsync(Guid id)
    {
        _repository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        var res = _repository.GetAll();
        var response =  await res.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            CategoryId = p.CategoryId,
            Status = p.Status,
            CreatedDate = p.CreatedDate,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            UpdatedDate = p.UpdatedDate,
            StatusName = ((ProductStatus)p.Status).ToString()
        }).ToListAsync();

        return response;
    }

    public async Task<ProductResponse> GetProductAsync(Guid id)
    {
        var res = await _repository.GetByIdAsync(id);
        return new ProductResponse
        {
            Id = res.Id,
            Name = res.Name,
            Description = res.Description,
            CategoryId = res.CategoryId,
            Status = res.Status,
            CreatedDate = res.CreatedDate,
            ImageUrl = res.ImageUrl,
            Price = res.Price,
            StockQuantity = res.StockQuantity,
            UpdatedDate = res.UpdatedDate,
            StatusName = ((ProductStatus)res.Status).ToString()
        };
    }

    public async Task<ProductResponse> UpdateProductAsync(ProductRequest Product)
    {
        await _repository.UpdateAsync(new Product
        {
            Id = Product.Id,
            Name = Product.Name,
            Description = Product.Description,
            CategoryId = Product.CategoryId,
            Price = Product.Price,
            StockQuantity = Product.StockQuantity,
            ImageUrl = Product.ImageUrl,
            UpdatedDate = DateTime.UtcNow,
            Status = Product.Status,
        });
        return new ProductResponse
        {
            Id = Product.Id,
            Name = Product.Name,
            Description = Product.Description,
            CategoryId = Product.CategoryId,
            Status = Product.Status,
            ImageUrl = Product.ImageUrl,
            Price = Product.Price,
            StockQuantity = Product.StockQuantity,
            StatusName = ((ProductStatus)Product.Status).ToString()

        };
    }
}
