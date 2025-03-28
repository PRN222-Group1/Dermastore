using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dermastore.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly DermastoreContext _context;

        public OrderService(DermastoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders
                        .Include(o => o.OrderItems)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders.Include(o => o.OrderItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }


    }
}
