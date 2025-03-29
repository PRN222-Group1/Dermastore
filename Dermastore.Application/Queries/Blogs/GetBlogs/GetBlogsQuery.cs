using Dermastore.Application.DTOs.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogs
{
    public class GetBlogsQuery : IRequest<IReadOnlyList<BlogDto>>
    {
    }
}
