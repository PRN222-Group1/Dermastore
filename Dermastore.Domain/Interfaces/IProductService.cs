using Dermastore.Domain.Entities;
using Dermastore.Domain.Specifications;

namespace Dermastore.Domain.Interfaces;

public interface IProductService
{
    Task<bool> EditProduct(int id, Product product);

    Task<bool> CreateProduct(Product product);
    Task<bool> DeleteProduct(int id);
    Task<IReadOnlyList<Product>> GetProducts(ISpecification<Product> spec);
    Task<Product> GetProduct(int id);
    Task<int> CountProduct(ISpecification<Product> spec);
}