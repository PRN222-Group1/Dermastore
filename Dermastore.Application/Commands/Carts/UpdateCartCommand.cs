using Dermastore.Application.DTOs.CartDTOs;
using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Commands.Carts
{
    public class UpdateCartCommand : IRequest<ShoppingCart>
    {
        public CartDto Cart { get; set; }

        public UpdateCartCommand(CartDto cart)
        {
            Cart = cart;
        }
    }
}
