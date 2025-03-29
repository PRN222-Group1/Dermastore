using Dermastore.Application.DTOs.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class CreateBlogCommand : IRequest<int>
    {
        public BlogToAddDto BlogDto { get; }

        public CreateBlogCommand(BlogToAddDto blogDto)
        {
            BlogDto = blogDto;
        }
    }
}
