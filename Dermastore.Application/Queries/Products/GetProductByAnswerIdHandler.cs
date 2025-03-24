using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductByAnswerIdHandler : IRequestHandler<GetProductByAnswerIdQuery, IReadOnlyList<ProductForQuizResultDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetProductByAnswerIdHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IReadOnlyList<ProductForQuizResultDto>> Handle(GetProductByAnswerIdQuery request, CancellationToken cancellationToken)
        {
            //var spec = new ProductSpecification(request.answerIds);
            //var product = await _productRepository.ListAsync(spec);
            var product = await _productRepository.ListAllAsync();
            return product.Select(p => p.toProductQuizDto()).ToList();
        }
    }
}
