using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IGenericRepository<Blog> _blogRepository;

    public UpdateBlogHandler(IGenericRepository<Blog> blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var spec = new BlogSpecification(request.BlogDto.Id);
        var blog = await _blogRepository.GetEntityWithSpec(spec);

        blog.UpdateFromDto(request.BlogDto);
            _blogRepository.Update(blog);
        await _blogRepository.SaveAllAsync();

        return blog.Id;
    }
}
}
