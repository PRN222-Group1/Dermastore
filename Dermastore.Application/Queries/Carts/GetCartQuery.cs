using Dermastore.Application.DTOs.CartDTOs;
using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Queries.Carts
{
    public class GetCartQuery : IRequest<CartDto>
    {
        public string Id { get; }

        public GetCartQuery(string id)
        {
            Id = id;
        }
    }
}
