using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = request.BlogDto.ToEntity();
            _unitOfWork.Blogs.CreateBlog(blog);
            await _unitOfWork.Complete();

            return blog.Id;
        }
    }
}
