using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, IReadOnlyList<BrandDto>>
    {
        private readonly IGenericRepository<Brand> _brandRepository;

        public GetBrandsHandler(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IReadOnlyList<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.ListAllAsync();
            return brands.Select(b => b.ToDto()).ToList();
        }
    }
}
