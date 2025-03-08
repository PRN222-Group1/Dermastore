using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Application.Interfaces;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;

namespace Dermastore.Application.Services;

public class ProductService : IProduct
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<bool> EditProduct(int id, ProductToUpdateDto product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product data is null");
        }

        Product productUpdate = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

        if (productUpdate == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        productUpdate.Name = product.Name;
        productUpdate.Description = product.Description;
        productUpdate.Status = product.Status;
        productUpdate.Quantity = product.Quantity;
        productUpdate.ImageUrl = product.ImageUrl;
        // productUpdate.AnswerId = product.AnswerId;
        productUpdate.SubCategoryId = product.CategoryId;

        _unitOfWork.Repository<Product>().Update(productUpdate);
        var result = await _unitOfWork.Complete();
        return result;
    }

    public async Task<bool> CreateProduct(ProductToAddDto product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product data is null");
        }

        try
        {
            var pd = new Product
            {
                Description = product.Description,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Status = product.Status,
                Quantity = product.Quantity,
                SubCategoryId = product.CategoryId
            };

            _unitOfWork.Repository<Product>().Add(pd);
            var result = await _unitOfWork.Complete();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating product: {ex.Message}");
            return false;
        }
    }


    public async Task<bool> DeleteProduct(int id)
    {
        var spec = new ProductSpecification(id);
        var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        product.Status = ProductStatus.Inactive;

        _unitOfWork.Repository<Product>().Update(product);
        var result = await _unitOfWork.Complete();
        return result;
    }

    public async Task<IReadOnlyList<ProductDto>> GetProducts()
    {
        var products = await _unitOfWork.Repository<Product>().ListAllAsync();
        return products?.Select(p => p.UpdateFromDto()).ToList() ?? new List<ProductDto>();
    }

    public async Task<ProductDto> GetProduct(int id)
    {
        var spec = new ProductSpecification(id);
        var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        return ProductMappingExtension.UpdateFromDto(product);
    }
}