using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class DeliveryMethodMappingExtension
    {
        public static DeliveryMethodDto ToDto(this DeliveryMethod deliveryMethod)
        {
            if (deliveryMethod == null)
            {
                return null;
            }
            return new DeliveryMethodDto
            {
                Id = deliveryMethod.Id,
                DeliveryTime = deliveryMethod.DeliveryTime,
                Description = deliveryMethod.Description,
                Name = deliveryMethod.Name,
                Price = deliveryMethod.Price
            };
        }

        public static DeliveryMethod ToEntity(this DeliveryMethodDto deliveryMethod)
        {
            if (deliveryMethod == null)
            {
                return null;
            }
            return new DeliveryMethod
            {
                Id = deliveryMethod.Id,
                DeliveryTime = deliveryMethod.DeliveryTime,
                Description = deliveryMethod.Description,
                Name = deliveryMethod.Name,
                Price = deliveryMethod.Price
            };
        }
    }
}
