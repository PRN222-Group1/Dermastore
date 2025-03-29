using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class CreatFeedbackHandler: IRequestHandler<CreateFeedbackCommand, int>
{
    private readonly IFeedbackService _feedbackService;

    public CreatFeedbackHandler(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }
    
    public async Task<int> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackService.CreateFeedback(request.Feedback);
        return request.Feedback.Id;
    }
}