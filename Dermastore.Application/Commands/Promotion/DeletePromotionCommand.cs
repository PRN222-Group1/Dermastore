using MediatR;

namespace Dermastore.Application.Commands.Promotion
{
    public class DeletePromotionCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeletePromotionCommand(int id)
        {
            Id = id;
        }
    }
}
