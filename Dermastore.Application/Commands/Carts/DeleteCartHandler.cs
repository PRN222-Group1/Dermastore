using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Carts
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, bool>
    {
        private readonly ICartService _cartService;

        public DeleteCartHandler(ICartService cartService) 
        {
            _cartService = cartService;
        }

        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartService.DeleteCartAsync(request.Id);
            return result;
        }
    }
}
