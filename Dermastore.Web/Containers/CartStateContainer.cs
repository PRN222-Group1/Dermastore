using Dermastore.Application.Commands.Carts;
using Dermastore.Application.DTOs.CartDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Application.Queries.Carts;
using MediatR;

namespace Dermastore.Web.Containers
{
    public class CartStateContainer
    {
        private readonly IMediator _mediator;
        private CartDto? _cart;

        public CartStateContainer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public CartDto Cart
        {
            get => _cart ?? null;
            private set
            {
                _cart = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        // Load cart from CartService using cartId from local storage
        public async Task LoadCartAsync(string cartId)
        {

            if (!string.IsNullOrEmpty(cartId))
            {
                var query = new GetCartQuery(cartId);
                var loadedCart = await _mediator.Send(query);
                Cart = loadedCart ?? null;
            }
        }

        // Update cart and save to CartService
        public async Task UpdateCartAsync(CartDto cart)
        {
            var command = new UpdateCartCommand(cart);
            var updatedCart = await _mediator.Send(command);
            Cart = updatedCart.ToDto();
        }

        // Delete cart both in state and Redis, remove cartId from local storage
        public async Task DeleteCartAsync()
        {
            if (_cart != null)
            {
                var command = new DeleteCartCommand(_cart.Id);
                var result = await _mediator.Send(command);

                if (result)
                {
                    Cart = null;
                }
            }

            NotifyStateChanged();
        }
    }
}
