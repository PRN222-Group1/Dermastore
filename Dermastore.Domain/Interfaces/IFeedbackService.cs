using Dermastore.Domain.Entities;
using Dermastore.Domain.Specifications;

namespace Dermastore.Domain.Interfaces;

public interface IFeedbackService
{
    Task<bool> EditFeedback(int id, Feedback product);

    Task<bool> CreateFeedback(Feedback product);
    Task<bool> DeleteFeedback(int id);
    Task<IReadOnlyList<Feedback>> GetFeedback(ISpecification<Feedback> spec);
    Task<IReadOnlyList<Feedback>> GetFeedback();
    Task<Feedback> GetFeedback(int id);
    Task<int> CountFeedback(ISpecification<Feedback> spec);
}