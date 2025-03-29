using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class CreateFeedbackCommand : IRequest<int>
{
    
    public Domain.Entities.Feedback Feedback { get; }

    public CreateFeedbackCommand(Domain.Entities.Feedback feedback)
    {
        Feedback = feedback;
    }}