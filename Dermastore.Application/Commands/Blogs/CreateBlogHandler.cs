using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Blogs
{
    public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IGenericRepository<Blog> _blogRepository;

        public CreateBlogHandler(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var product = request.BlogDto.ToEntity();
            _blogRepository.Add(product);
            await _blogRepository.SaveAllAsync();

            return product.Id;
        }
    }
}
