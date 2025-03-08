using Dermastore.Application.DTOs.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs
{
    public class GetBlogQuery : IRequest<BlogDto>
    {
        public int Id { get; }

        public GetBlogQuery(int id)
        {
            Id = id;
        }
    }
}
