using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    class GetMostSoldProductHandler : IRequestHandler<GetMostSoldProductQuery, Dictionary<ProductDto, int>?>
    {
        private readonly IDashboardService _dashboardService;

        public GetMostSoldProductHandler(IDashboardService dashboardService) 
        {
            _dashboardService = dashboardService;
        }
        public async Task<Dictionary<ProductDto, int>?> Handle(GetMostSoldProductQuery request, CancellationToken cancellationToken)
        {
            var dict = await _dashboardService.GetMostSoldProduct();
            var dictToReturn = new Dictionary<ProductDto?, int>()
            {
                {dict.FirstOrDefault().Key.ToDto(), dict.FirstOrDefault().Value }
            };
            return dictToReturn;
        }
    }
}
