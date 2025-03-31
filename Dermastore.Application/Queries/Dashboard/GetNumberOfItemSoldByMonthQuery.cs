using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetNumberOfItemSoldByMonthQuery : IRequest<Dictionary<int, int>>
    {
        public int Year { get; set; }

        public GetNumberOfItemSoldByMonthQuery(int year)
        {
            Year = year;
        }
    }
}
