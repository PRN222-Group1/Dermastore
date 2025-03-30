using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Specifications;

namespace Dermastore.Domain.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetNumberOfOrdersByStatus(string status);
        Task<Dictionary<Product, int>?> GetMostSoldProduct();
        Task<Dictionary<int, int>> GetNumberOfItemSoldByMonth(int year);
        Task<Dictionary<int, decimal>> GetRevenueByMonth(int year);
        Task<Dictionary<string, int>> GetNumberOfBlogsByStaff();
    }
}
