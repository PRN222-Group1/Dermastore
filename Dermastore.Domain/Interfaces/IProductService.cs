using Dermastore.Domain.Entities;

namespace Dermastore.Domain.Interfaces;

public interface IProductService
{
    Task<bool> EditProduct(int id, Product product);

    Task<bool> CreateProduct(Product product);
    Task<bool> DeleteProduct(int id);
    Task<IReadOnlyList<Product>> GetProducts();
    Task<Product> GetProduct(int id);



}