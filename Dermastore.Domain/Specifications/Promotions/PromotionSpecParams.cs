using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Specifications.Promotions
{
    public class PromotionSpecParams : PagingParams
    {
        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value;
        }
    }

    public class PagingParams
    {
        private const int MaxPageSize = 30;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 12;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
