namespace Dermastore.Domain.Specifications.Blogs
{
    public class BlogSpecParams : PagingParams
    {
        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value;
        }
        public int? UserId { get; set; }
        public string? Sort { get; set; }
        public string? Status { get; set; }
    }
}
