using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class UpdataFeedbackCommand : IRequest<int>
{
    public Domain.Entities.Feedback Feedback { get; set; }

    public UpdataFeedbackCommand(Domain.Entities.Feedback feedback)
    {
        Feedback = feedback;
    }
}