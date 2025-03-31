using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfBlogsByStaffHandler : IRequestHandler<GetNumberOfBlogsByStaffQuery, Dictionary<string, int>>
    {
        private readonly IDashboardService _dashboardService;

        public GetNumberOfBlogsByStaffHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<Dictionary<string, int>> Handle(GetNumberOfBlogsByStaffQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetNumberOfBlogsByStaff();
        }
    }
}
