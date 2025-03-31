using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications;
using Dermastore.Domain.Specifications.Promotions;

namespace Dermastore.Infrastructure.Services
{

    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CountPromotion(ISpecification<Promotion> spec)
        {
            var result = await _unitOfWork.Repository<Promotion>().CountAsync(spec);
            return result;
        }

        public async Task<int> CreatePromotion(Promotion promotion)
        {
            if(promotion == null)
            {
                throw new ArgumentNullException(nameof(promotion), "Promotion data is null");
            }
            try
            {
                var promotionToAdd = new Promotion
                {
                    Code = promotion.Code,
                    Discount = promotion.Discount,
                    Name = promotion.Name,
                    EffectiveDate = promotion.EffectiveDate,
                    ExpiryDate = promotion.ExpiryDate
                };

                _unitOfWork.Repository<Promotion>().Add(promotionToAdd);
                await _unitOfWork.Complete();
                return promotionToAdd.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
                return 0;
            }
        }

        public async Task<Promotion> GetPromotion(int id)
        {
            var spec = new PromotionSpecification(id);
            var result = await _unitOfWork.Repository<Promotion>().GetEntityWithSpec(spec);
            if (result == null)
            {
                throw new KeyNotFoundException($"Promotion with ID {id} not found");
            }
            return result;
        }

        public async Task<IReadOnlyList<Promotion>> GetPromotions(ISpecification<Promotion> spec)
        {
            var result = await _unitOfWork.Repository<Promotion>().ListAsync(spec);
            return result ?? new List<Promotion>();
        }

        public async Task<bool> EditPromotion(int id, Promotion product)
        {
            var repository = _unitOfWork.Repository<Promotion>();
            Promotion promotionToUpdate = await repository.GetByIdAsync(id);

            if (promotionToUpdate == null)
            {
                throw new KeyNotFoundException($"Promotion with ID {id} not found");
            }

            promotionToUpdate.Code = product.Code;
            promotionToUpdate.Discount = product.Discount;
            promotionToUpdate.Name = product.Name;
            promotionToUpdate.EffectiveDate = product.EffectiveDate;
            promotionToUpdate.ExpiryDate = product.ExpiryDate;
            promotionToUpdate.Status = product.Status;

            repository.Update(promotionToUpdate);

            return await _unitOfWork.Complete();
        }

        public async Task<bool> DeletePromotion(int id)
        {
            var promotion = await _unitOfWork.Repository<Promotion>().GetByIdAsync(id);

            if (promotion == null)
            {
                throw new KeyNotFoundException($"Promotion with ID {id} not found");
            }

            _unitOfWork.Repository<Promotion>().Delete(promotion);
            var result = await _unitOfWork.Complete();
            return result;
        }
    }
}
