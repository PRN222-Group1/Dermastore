using Dermastore.Application.DTOs.Blogs;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogs
{
    public class GetBlogsQuery : IRequest<IReadOnlyList<BlogDto>>
    {
        public BlogSpecParams BlogSpecParams { get; set; }
        public GetBlogsQuery(BlogSpecParams specParams)
        {
            BlogSpecParams = specParams;
        } 
    }
}
