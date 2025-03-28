using Dermastore.Application.DTOs;
using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogs
{
    public class GetBlogsHandler : IRequestHandler<GetBlogsQuery, IReadOnlyList<BlogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlogsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _unitOfWork.Blogs.GetBlogs();
            var blogsToReturn = blogs.Select(p => p.ToDto()).ToList();
            return blogsToReturn;
        }
    }
}
