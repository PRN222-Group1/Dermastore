using MediatR;

namespace Dermastore.Application.Commands.Answers
{
    public class DeleteAnswerCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteAnswerCommand(int id)
        {
            Id = id;
        }
    }
}
