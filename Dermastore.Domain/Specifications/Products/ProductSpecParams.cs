using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Products
{
    public class ProductSpecParams : PagingParams
    {
        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value;
        }

        public List<int> SubCategoryIds { get; set; } = new List<int>();
        public string? Sort { get; set; }
        public string? Status { get; set; }
        public List<int> BrandIds { get; set; } = new List<int>();
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
    }
}
