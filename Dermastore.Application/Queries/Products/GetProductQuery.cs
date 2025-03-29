using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public int Id {  get; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
