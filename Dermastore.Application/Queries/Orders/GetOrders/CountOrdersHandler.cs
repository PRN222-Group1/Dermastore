using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Queries.Orders.GetOrders
{
    public class CountOrdersHandler : IRequestHandler<CountOrdersQuery, int>
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public CountOrdersHandler(IGenericRepository<Order> orderRepo) 
        {
            _orderRepo = orderRepo;
        }
        public async Task<int> Handle(CountOrdersQuery request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification(request.OrderSpecParams);
            var count = await _orderRepo.CountAsync(spec);
            return count;
        }
    }
}
