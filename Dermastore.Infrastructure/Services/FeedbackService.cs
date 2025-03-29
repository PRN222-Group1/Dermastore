using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications;

namespace Dermastore.Infrastructure.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IUnitOfWork _unitOfWork;

    public FeedbackService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> EditFeedback(int id, Feedback product)
    {
        
        var repository = _unitOfWork.Repository<Feedback>();
        Feedback feedback = await repository.GetByIdAsync(id);
        if (feedback == null)
            throw new KeyNotFoundException($"Feeback with ID {id} not found");

        feedback.Content = product.Content;
        feedback.CreatedDate = product.CreatedDate;

        repository.Update(feedback);

        return await _unitOfWork.Complete();
    }

    public async Task<bool> CreateFeedback(Feedback product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Feedback data is null");

        try
        {
            var feedback = new Feedback
            {
                Content = product.Content,
                CreatedDate = product.CreatedDate,
                UserId = product.UserId
            };
            _unitOfWork.Repository<Feedback>().Add(feedback);
            var result = await _unitOfWork.Complete();
            return result;
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteFeedback(int id)
    {
        var feeback = await _unitOfWork.Repository<Feedback>().GetByIdAsync(id);

        if (feeback == null)
            throw new KeyNotFoundException($"Feeback with ID {id} not found");


        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Feedback>> GetFeedback(ISpecification<Feedback> spec)
    {
        var feeback = await _unitOfWork.Repository<Feedback>().ListAsync(spec);
        return feeback ?? new List<Feedback>();
    }

    public async Task<Feedback> GetFeedback(int id)
    {
        var feeback = await _unitOfWork.Repository<Feedback>().GetByIdAsync(id);
        return feeback;
    }

    public async Task<int> CountFeedback(ISpecification<Feedback> spec)
    {
        var count = await _unitOfWork.Repository<Feedback>().CountAsync(spec);
        return count;
    }
}