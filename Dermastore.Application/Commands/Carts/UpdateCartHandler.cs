using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Carts
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, ShoppingCart>
    {
        private readonly ICartService _cartService;

        public UpdateCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<ShoppingCart> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.SetCartAsync(request.Cart.UpdateFromDto());
            if (cart == null) return null!;
            return cart;
        }
    }
}
