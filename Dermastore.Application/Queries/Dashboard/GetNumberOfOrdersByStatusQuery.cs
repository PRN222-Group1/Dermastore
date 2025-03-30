using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfOrdersByStatusQuery : IRequest<int>
    {
        public string Status { get; set; }

        public GetNumberOfOrdersByStatusQuery(string status)
        {
            Status = status;
        }
    }
}
