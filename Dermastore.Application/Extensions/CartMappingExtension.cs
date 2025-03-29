using Dermastore.Application.DTOs.CartDTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class CartMappingExtension
    {
        public static CartItemDto ToDto(this CartItem item)
        {
            if (item == null)
            {
                return null;
            }
            return new CartItemDto
            {
                ProductId = item.ProductId,
                ImageUrl = item.ImageUrl,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity,
            };
        }

        public static CartDto ToDto(this ShoppingCart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartDto
            {
                Id = cart.Id,
                Items = cart.Items.Select(i => i.ToDto()).ToList(),
                Promotion = cart.Promotion != null ? cart.Promotion.ToDto() : null,
                DeliveryMethod = cart.DeliveryMethod != null ? cart.DeliveryMethod.ToDto() : null,
            };
        }

        public static CartItem UpdateFromDto(this CartItemDto item)
        {
            if (item == null)
            {
                return null;
            }
            return new CartItem
            {
                ProductId = item.ProductId,
                ImageUrl = item.ImageUrl,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity,
            };
        }

        public static ShoppingCart UpdateFromDto(this CartDto cart)
        {
            if (cart == null)
            {
                return null;
            }

            return new ShoppingCart
            {
                Id = cart.Id,
                Items = cart.Items.Select(i => i.UpdateFromDto()).ToList(),
                Promotion = cart.Promotion != null ? cart.Promotion.ToEntity() : null,
                DeliveryMethod = cart.DeliveryMethod != null ? cart.DeliveryMethod.ToEntity() : null,
            };
        }
    }
}
