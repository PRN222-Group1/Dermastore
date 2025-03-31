using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.SubCategories
{
    public class GetSubCategoriesHandler : IRequestHandler<GetSubCategoriesQuery, IReadOnlyList<SubCategoryDto>>
    {
        private readonly IGenericRepository<SubCategory> _subCategoryRepository;

        public GetSubCategoriesHandler(IGenericRepository<SubCategory> subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IReadOnlyList<SubCategoryDto>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategoryRepository.ListAllAsync();
            return subCategories.Select(sc => sc.ToDto()).ToList();
        }
    }
}
