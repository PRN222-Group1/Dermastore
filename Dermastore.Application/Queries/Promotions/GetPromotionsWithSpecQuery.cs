using Dermastore.Application.DTOs;
using Dermastore.Domain.Specifications.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Promotions
{
    public class GetPromotionsWithSpecQuery : IRequest<IReadOnlyList<PromotionDto>>
    {
        public PromotionSpecParams PromotionParams { get; set; }
        public GetPromotionsWithSpecQuery(PromotionSpecParams promotionParams)
        {
            PromotionParams = promotionParams;
        }
    }
}
