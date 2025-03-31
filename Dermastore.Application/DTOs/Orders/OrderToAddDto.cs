using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.Orders
{
    public class OrderToAddDto
    {
        public required DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string ShippingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public int UserId { get; set; }
        public int? PromotionId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int? MembershipId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
