using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogs
{
    public class CountBlogsQuery : IRequest<int>
    {
        public BlogSpecParams BlogSpecParams { get; set; }

        public CountBlogsQuery(BlogSpecParams blogSpecParams)
        {
            BlogSpecParams = blogSpecParams;
        }
    }
}
