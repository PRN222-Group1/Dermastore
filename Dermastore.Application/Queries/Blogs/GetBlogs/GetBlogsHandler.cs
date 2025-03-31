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
        private readonly IGenericRepository<Blog> _blogRepository;

        public GetBlogsHandler(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IReadOnlyList<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var spec = new BlogSpecification(request.BlogSpecParams);
            var blogs = await _blogRepository.ListAsync(spec);
            var blogsToReturn = blogs.Select(p => p.ToDto()).ToList();
            return blogsToReturn;
        }
    }
}
