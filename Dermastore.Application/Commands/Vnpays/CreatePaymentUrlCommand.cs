using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Vnpays
{
    
       public class CreatePaymentUrlCommand : IRequest<string>
    {
        public int OrderId { get; }

        public CreatePaymentUrlCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}

