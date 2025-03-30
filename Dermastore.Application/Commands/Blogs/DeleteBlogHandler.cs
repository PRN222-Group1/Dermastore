using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IGenericRepository<Blog> _blogRepository;

        public DeleteBlogHandler(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var spec = new BlogSpecification(request.Id);
            var blog = await _blogRepository.GetEntityWithSpec(spec);

            blog.Status = BlogStatus.Draft;
            var result = await _blogRepository.SaveAllAsync();

            return result;
        }
    }
}
