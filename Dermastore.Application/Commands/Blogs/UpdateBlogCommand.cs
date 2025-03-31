
using Dermastore.Application.DTOs.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public BlogToUpdateDto BlogDto { get; }

        public UpdateBlogCommand(BlogToUpdateDto blogDto)
        {
            BlogDto = blogDto;
        }
    }
}
