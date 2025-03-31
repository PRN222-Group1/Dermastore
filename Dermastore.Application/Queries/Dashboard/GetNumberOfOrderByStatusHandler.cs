using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfOrdersByStatusHandler : IRequestHandler<GetNumberOfOrdersByStatusQuery, int>
    {
        private readonly IDashboardService _dashboardService;

        public GetNumberOfOrdersByStatusHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<int> Handle(GetNumberOfOrdersByStatusQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetNumberOfOrdersByStatus(request.Status);
        }
    }
}
