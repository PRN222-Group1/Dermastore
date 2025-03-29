using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Feedback;

public class DeleteFeedbackHandler : IRequestHandler<DeleteFeedbackCommand, bool>
{
    private readonly IFeedbackService _feedbackService;

    public DeleteFeedbackHandler(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }


    public async Task<bool> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackService.DeleteFeedback(request.Id);
        return feedback;
    }
}