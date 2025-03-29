using Dermastore.Application.DTOs;
using Dermastore.Application.DTOs.Orders;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;

namespace Dermastore.Application.Extensions
{
    public static class OrderItemMappingExtension
    {
        public static OrderItemDto ToDto(this OrderItem orderItem)
        {
            if (orderItem == null) return null;

            return new OrderItemDto
            {
                ItemOrdered = orderItem.ItemOrdered.ToDto(),
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
            };
        }

        public static OrderItem ToEntity(this OrderItemDto orderItemDto)
        {
            if (orderItemDto == null) throw new ArgumentNullException(nameof(orderItemDto));

            return new OrderItem
            {
                ItemOrdered = orderItemDto.ItemOrdered.ToEntity(),
                Price = orderItemDto.Price,
                Quantity = orderItemDto.Quantity,
            };
        }
    }
}
