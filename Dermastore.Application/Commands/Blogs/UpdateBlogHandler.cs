using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBlogHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        
        var blog = await _unitOfWork.Blogs.GetBlogById(request.BlogDto.Id);
         _unitOfWork.Blogs.Update(blog);
            await _unitOfWork.Complete();

            return blog.Id;
    }
}
}
