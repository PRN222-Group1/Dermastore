using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetRevenueByMonthQuery : IRequest<Dictionary<int, decimal>>
    {
        public int Year { get; set; }
        public GetRevenueByMonthQuery(int year)
        {
            Year = year;
        }
    }
}
