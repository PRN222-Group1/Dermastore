using Dermastore.Application.DTOs.Blogs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Queries.Blogs.GetBlogs
{
    class CountBlogsHandler : IRequestHandler<CountBlogsQuery, int>
    {
        private readonly IGenericRepository<Blog> _blogRepository;

        public CountBlogsHandler(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(CountBlogsQuery request, CancellationToken cancellationToken)
        {
            var spec = new BlogSpecification(request.BlogSpecParams);
            var count = await _blogRepository.CountAsync(spec);
            return count;
        }
    }
}
