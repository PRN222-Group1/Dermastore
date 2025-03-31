using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Promotions
{
    public class GetPromotionQuery : IRequest<PromotionDto>
    {
        public int Id { get; }
        public string Code { get; }


        public GetPromotionQuery(int id)
        {
            Id = id;
        }

        public GetPromotionQuery(string code) 
        {
            Code = code;
        }
    }
}
