using MediatR;

namespace Dermastore.Application.Commands.Orders
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public CancelOrderCommand(int id) 
        {
            Id = id;
        }
    }
}
