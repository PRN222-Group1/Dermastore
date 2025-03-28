using Dermastore.Application.DTOs.CartDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Carts
{
    public class GetCartHandler : IRequestHandler<GetCartQuery, CartDto>
    {
        private readonly ICartService _cartService;

        public GetCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.GetCartAsync(request.Id);

            if (cart == null) return null!;

            return cart.ToDto();
        }
    }
}
