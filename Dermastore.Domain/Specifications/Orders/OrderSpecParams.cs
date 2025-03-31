namespace Dermastore.Domain.Specifications.Orders
{
    public class OrderSpecParams : PagingParams
    {
        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value;
        }
        public int? Year { get; set; }
        public int? UserId { get; set; }
        public string? Sort { get; set; }
        public string? Status { get; set; }
    }
}
