using MediatR;

namespace Dermastore.Application.Commands.Carts
{
    public class DeleteCartCommand : IRequest<bool>
    {
        public string Id { get; set; }
        
        public DeleteCartCommand(string id)
        {
            Id = id;
        }
    }
}
