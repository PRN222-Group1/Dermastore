using Dermastore.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Promotion
{
    public class CreatePromotionCommand : IRequest<int>
    {
        public PromotionDto PromotionDto { get; set; }

        public CreatePromotionCommand(PromotionDto promotionDto)
        {
            PromotionDto = promotionDto;
        }
    }
}
