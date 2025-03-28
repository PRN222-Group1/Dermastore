using Dermastore.Application.DTOs;
using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.Extensions;
using Dermastore.Application.Queries.Products;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogById
{
    public class GetBlogHandler : IRequestHandler<GetBlogQuery, BlogDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlogHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogDto> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _unitOfWork.Blogs.GetBlogById(request.Id);
            return blog.ToDto();
        }
    }
}
