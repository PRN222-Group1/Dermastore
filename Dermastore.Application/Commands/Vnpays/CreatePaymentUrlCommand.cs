using MediatR;

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

