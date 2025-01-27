using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<Category>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public GetCategoriesHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ListAllAsync();
            return categories;
        }
    }
}
