using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class DeleteFeedbackCommand: IRequest<bool>
{
    public int Id { get; }

    public DeleteFeedbackCommand(int id)
    {
        Id = id;
    }
}