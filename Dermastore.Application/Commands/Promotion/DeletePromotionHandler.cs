using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Promotion
{
    public class DeletePromotionHandler : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IPromotionService _promotionService;

        public DeletePromotionHandler(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            return await _promotionService.DeletePromotion(request.Id);
        }
    }
}
