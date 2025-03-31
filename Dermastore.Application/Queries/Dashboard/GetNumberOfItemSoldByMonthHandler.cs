using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfItemSoldByMonthHandler : IRequestHandler<GetNumberOfItemSoldByMonthQuery, Dictionary<int, int>>
    {
        private readonly IDashboardService _dashboardService;

        public GetNumberOfItemSoldByMonthHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<Dictionary<int, int>> Handle(GetNumberOfItemSoldByMonthQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetNumberOfItemSoldByMonth(request.Year);
        }
    }
}
