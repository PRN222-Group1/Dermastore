using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Orders;

namespace Dermastore.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IReadOnlyList<Order>> GetOrders()
        {
            return await _orderRepository.ListAllAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var spec = new OrderSpecification(orderId);
            return await _orderRepository.GetEntityWithSpec(spec);
        }

        public async Task<int> CreateOrder(Order order)
        {
            _orderRepository.Add(order);
            await _orderRepository.SaveAllAsync();
            return order.Id;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            _orderRepository.Delete(order);
            return await _orderRepository.SaveAllAsync();
        }

        public async Task<int> UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            await _orderRepository.SaveAllAsync();
            return order.Id;
        }

        public async Task<int> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            order.Status = status;
            _orderRepository.Update(order);
            await _orderRepository.SaveAllAsync();
            return order.Id;


        }
    }
}
