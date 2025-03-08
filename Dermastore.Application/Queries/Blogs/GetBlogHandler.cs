using Dermastore.Application.DTOs;
using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.Extensions;
using Dermastore.Application.Queries.Products;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs
{
    public class GetBlogHandler : IRequestHandler<GetBlogQuery, BlogDto>
    {
        private readonly IGenericRepository<Blog> _blogRepository;

        public GetBlogHandler(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogDto> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var spec = new BlogSpecification(request.Id);
            var blog = await _blogRepository.GetEntityWithSpec(spec);
            return blog.ToDto();
        }
    }
}
