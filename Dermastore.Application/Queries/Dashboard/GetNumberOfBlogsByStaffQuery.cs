using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfBlogsByStaffQuery : IRequest<Dictionary<string, int>>
    {
    }
}
