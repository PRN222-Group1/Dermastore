using Dermastore.Domain.Entities;
using Dermastore.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Interfaces
{
    public interface IPromotionService
    {
        Task<IReadOnlyList<Promotion>> GetPromotions(ISpecification<Promotion> spec);
        Task<int> CountPromotion(ISpecification<Promotion> spec);
        Task<int> CreatePromotion(Promotion promotion);
        Task<Promotion> GetPromotion(int id);
        Task<bool> EditPromotion(int id, Promotion product);
        Task<bool> DeletePromotion(int id);
    }
}
