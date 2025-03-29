using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.DeliveryMethods
{
    public class GetDeliveryMethodQuery : IRequest<DeliveryMethodDto>
    {
        public int Id { get; }

        public GetDeliveryMethodQuery(int id)
        {
            Id = id;
        }
    }
}
