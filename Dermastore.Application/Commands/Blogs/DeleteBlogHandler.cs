using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBlogHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            
            var blog = await _unitOfWork.Blogs.GetBlogById(request.Id);

            _unitOfWork.Blogs.Remove(blog);
            var result = await _unitOfWork.Complete();

            return result;
        }
    }
}
