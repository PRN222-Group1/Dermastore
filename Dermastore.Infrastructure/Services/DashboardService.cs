using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using Dermastore.Domain.Specifications.Orders;
using Dermastore.Domain.Specifications.Products;
namespace Dermastore.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Dictionary<Product, int>?> GetMostSoldProduct()
        {
            var spec = new OrderSpecification();
            var orders = await _unitOfWork.Repository<Order>().ListAsync(spec);

            // Group all order items by a unique identifier (e.g., item ID) across all orders
            var groupedOrderItems = orders
                .SelectMany(order => order.OrderItems)
                .GroupBy(item => item.ItemOrdered.ProductId) // Assuming 'Id' uniquely identifies each OrderItem
                .Select(group => new
                {
                    Item = group.First(), // Get any representative item (e.g., first one in the group)
                    TotalQuantity = group.Sum(item => item.Quantity) // Sum quantities for each item
                })
                .OrderByDescending(g => g.TotalQuantity) // Sort by highest total quantity
                .FirstOrDefault(); // Get the item with the highest total quantity

            // If an item was found, you can access it here
            if (groupedOrderItems != null)
            {
                var highestQuantityItemId = groupedOrderItems.Item.ItemOrdered.ProductId;
                var highestQuantity = groupedOrderItems.TotalQuantity;

                var productSpec = new ProductSpecification(highestQuantityItemId);
                var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(productSpec);

                var dict = new Dictionary<Product, int>
                {
                    { product, highestQuantity }
                };

                return dict;
            }

            return null;
        }

        public async Task<Dictionary<string, int>> GetNumberOfBlogsByStaff()
        {
            // Get all staffs
            var staffs = await _userService.GetUsersInRoleAsync(UserRole.Staff.ToString());

            var dictList = new Dictionary<string, int>();

            // Loop through all the staffs
            foreach (var staff in staffs)
            {
                // Count the blogs created by the staff and add to dictList
                var specParams = new BlogSpecParams();
                specParams.UserId = staff.Id;
                var blogSpec = new BlogSpecification(staff.Id);
                var blogCount = await _unitOfWork.Repository<Blog>().CountAsync(blogSpec);
                dictList.Add(staff.FirstName + " " + staff.LastName, blogCount);
            }

            return dictList;
        }

        public async Task<int> GetNumberOfOrdersByStatus(string status)
        {
            var specParams = new OrderSpecParams();
            specParams.Status = status;

            var spec = new OrderSpecification(specParams);
            var count = await _unitOfWork.Repository<Order>().CountAsync(spec);

            return count;
        }

        public async Task<Dictionary<int, int>> GetNumberOfItemSoldByMonth(int year)
        {
            var specParams = new OrderSpecParams();
            specParams.Year = year;

            var spec = new OrderSpecification();
            var orders = await _unitOfWork.Repository<Order>().ListAsync(spec);

            var result = orders
                .GroupBy(order => order.OrderDate.Month) // Group by month
                .Select(group => new
                {
                    Month = group.Key,
                    TotalItemsSold = group.Sum(order => order.OrderItems.Sum(item => item.Quantity)) // Sum of quantities sold in the month
                })
                .ToDictionary(g => g.Month, g => g.TotalItemsSold); // Convert to Dictionary<Month, TotalItemsSold>

            return result;
        }


        public async Task<Dictionary<int, decimal>> GetRevenueByMonth(int year)
        {
            var specParams = new OrderSpecParams();
            specParams.Year = year;

            var spec = new OrderSpecification();
            var orders = await _unitOfWork.Repository<Order>().ListAsync(spec);

            var result = orders
                .GroupBy(order => order.OrderDate.Month) // Group by month
                .Select(group => new
                {
                    Month = group.Key,
                    TotalRevenue = group.Sum(order => order.GetTotal()) // Sum total revenue for each month
                })
                .ToDictionary(g => g.Month, g => g.TotalRevenue); // Convert to Dictionary<Month, TotalRevenue>

            return result;
        }

    }
}
