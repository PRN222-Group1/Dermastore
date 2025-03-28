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
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(int orderId);
        void CreateOrder(Order order);
        void Update(Order order);
        void Remove(Order order);
    }
}
