using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<Order>> GetOrders();
        Task<Order> GetOrderById(int orderId);
        Task<int> CreateOrder(Order order);
        Task<int> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int orderId);
        Task<int> ChangeOrderStatus(int orderId, OrderStatus status);


    }
}
