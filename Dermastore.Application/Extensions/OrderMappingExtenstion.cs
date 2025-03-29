using Dermastore.Application.DTOs.Orders;
using Dermastore.Domain.Entities.OrderAggregate;

namespace Dermastore.Application.Extensions
{
    public static class OrderMappingExtenstion
    {
        public static OrderDto ToDto(this Order order)
        {
            if (order == null) return null;
            return new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                SubTotal = order.SubTotal,
                UserId = order.UserId,
                PromotionId = order.PromotionId.HasValue ? order.PromotionId.Value : null,
                MembershipId = order.MembershipId.HasValue ? order.MembershipId.Value : null,
                DeliveryMethodId = order.DeliveryMethodId,
                Status = order.Status,
                OrderItems = order.OrderItems,
            };
        }

        public static Order ToEntity(this OrderToAddDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            return new Order
            {
                OrderDate = orderDto.OrderDate,
                ShippingAddress = orderDto.ShippingAddress,
                SubTotal = 0,
                UserId = orderDto.UserId,
                PromotionId = orderDto.PromotionId.HasValue ? orderDto.PromotionId : null,
                MembershipId = orderDto.MembershipId.HasValue ? orderDto.MembershipId : null,
                DeliveryMethodId = orderDto.DeliveryMethodId,
                Status = orderDto.Status,
                OrderItems = orderDto.OrderItems.Select(o => o.ToEntity()).ToList(),
            };
        }

        public static void UpdateFromDto(this Order order, OrderToUpdateDto orderDTO)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (orderDTO == null) throw new ArgumentNullException(nameof(orderDTO));

            order.OrderDate = orderDTO.OrderDate;
            order.ShippingAddress = orderDTO.ShippingAddress;
            order.SubTotal = orderDTO.SubTotal;
            order.UserId = orderDTO.UserId;
            order.PromotionId = orderDTO.PromotionId;
            order.DeliveryMethodId = orderDTO.DeliveryMethodId;
            order.Status = orderDTO.Status;
            order.OrderItems = orderDTO.OrderItems;
            
        }
    }
}
