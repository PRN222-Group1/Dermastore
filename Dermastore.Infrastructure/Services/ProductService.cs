using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;

namespace Dermastore.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;


    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<bool> EditProduct(int id, Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product data is null");
        }

        var repository = _unitOfWork.Repository<Product>();
        if (repository == null)
        {
            throw new InvalidOperationException("Product repository is not available.");
        }

        // Lấy sản phẩm trước khi bắt đầu transaction mới
        Product productUpdate = await repository.GetByIdAsync(id);

        if (productUpdate == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        // Cập nhật thông tin
        productUpdate.Name = product.Name;
        productUpdate.Description = product.Description;
        productUpdate.Status = product.Status;
        productUpdate.Quantity = product.Quantity;
        productUpdate.ImageUrl = product.ImageUrl;
        productUpdate.SubCategoryId = product.SubCategoryId;

        repository.Update(productUpdate);
        repository.SaveAllAsync();
        // Chờ transaction hoàn thành trước khi tiếp tục
        var result = await _unitOfWork.Complete();
        return result;
    }



    public async Task<bool> CreateProduct(Product product)
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
                SubCategoryId = product.SubCategoryId
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

        product.Status = ProductStatus.InStock;

        _unitOfWork.Repository<Product>().Update(product);
        var result = await _unitOfWork.Complete();
        return result;
    }


    public async Task<IReadOnlyList<Product>> GetProducts()
    {
        var products = await _unitOfWork.Repository<Product>().ListAllAsync();
        return products ?? new List<Product>();
    }


    public async Task<Product> GetProduct(int id)
    {
        var spec = new ProductSpecification(id);
        var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found");
        }

        return product;
    }
}