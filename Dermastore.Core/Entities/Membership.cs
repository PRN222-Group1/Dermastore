using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dermastore.Core.Entities
{
    public class Membership : BaseEntity
    {
        public required string Name { get; set; }

        public required int MinPoint { get; set; }

        public required decimal Discount { get; set; } = 0;
    }
}
