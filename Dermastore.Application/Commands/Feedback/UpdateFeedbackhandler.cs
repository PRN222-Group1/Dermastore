using Dermastore.Application.Commands.Answers;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class UpdateFeedbackhandler : IRequestHandler<UpdataFeedbackCommand, int>
{
    public readonly IFeedbackService FeedbackService;

    public UpdateFeedbackhandler(IFeedbackService feedbackService)
    {
        FeedbackService = feedbackService;
    }
    
    public async Task<int> Handle(UpdataFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await FeedbackService.EditFeedback(request.Feedback.Id,request.Feedback);
        return feedback.GetHashCode();
    }
}