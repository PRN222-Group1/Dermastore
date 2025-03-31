using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetRevenueByMonthHandler : IRequestHandler<GetRevenueByMonthQuery, Dictionary<int, decimal>>
    {
        private readonly IDashboardService _dashboardService;

        public GetRevenueByMonthHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<Dictionary<int, decimal>> Handle(GetRevenueByMonthQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetRevenueByMonth(request.Year);
        }
    }
}
