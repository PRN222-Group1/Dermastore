using Dermastore.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Products
{
    class DetailProductCommand : IRequest<int>
    {
        private ProductDto productDto { get; set; }

        public DetailProductCommand(ProductDto productDto)
        {
            this.productDto = productDto;
        }

    }
}
