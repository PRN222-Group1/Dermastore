using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class DeleteProductCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            this.Id = id;
        }
    }
}
