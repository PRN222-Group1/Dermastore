using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public CreateOrderHandler(IGenericRepository<Order> orderRepository, IGenericRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.OrderDto.ToEntity();

            foreach(var item in order.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ItemOrdered.ProductId);
                if  (product != null)
                {
                    // Get the official price of the product to prevent price modification on client
                    order.SubTotal += (product.Price * item.Quantity);
                }
            }

            _orderRepository.Add(order);
            await _orderRepository.SaveAllAsync();

            return order.Id;
        }
    }
}
