using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Interfaces;

public interface IProduct
{
    Task<bool> EditProduct(int id,ProductToUpdateDto product);
    
    Task<bool> CreateProduct(ProductToAddDto product);
    Task<bool> DeleteProduct(int id);
    Task<IReadOnlyList<ProductDto>> GetProducts();
    Task<ProductDto> GetProduct(int id);
    
    
}