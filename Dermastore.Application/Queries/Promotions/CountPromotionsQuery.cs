using Dermastore.Domain.Specifications.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Promotions
{
    public class CountPromotionsQuery : IRequest<int>
    {
        public PromotionSpecParams PromotionParams { get; set; }

        public CountPromotionsQuery(PromotionSpecParams promotionParams)
        {
            PromotionParams = promotionParams;
        }
    }
}
