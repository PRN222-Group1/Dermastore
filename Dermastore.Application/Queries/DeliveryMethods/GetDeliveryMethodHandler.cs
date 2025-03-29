using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.DeliveryMethods
{
    public class GetDeliveryMethodHandler : IRequestHandler<GetDeliveryMethodQuery, DeliveryMethodDto>
    {
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepo;

        public GetDeliveryMethodHandler(IGenericRepository<DeliveryMethod> deliveryMethodRepo)
        {
            _deliveryMethodRepo = deliveryMethodRepo;
        }

        public async Task<DeliveryMethodDto> Handle(GetDeliveryMethodQuery request, CancellationToken cancellationToken)
        {
            var deliveryMethod = await _deliveryMethodRepo.GetByIdAsync(request.Id);
            return deliveryMethod.ToDto();
        }
    }
}
