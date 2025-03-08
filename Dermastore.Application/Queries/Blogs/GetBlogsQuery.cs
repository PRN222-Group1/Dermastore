using Dermastore.Application.DTOs.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs
{
    public class GetBlogsQuery : IRequest<IReadOnlyList<BlogDto>>
    {
    }
}
