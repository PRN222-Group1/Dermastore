using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Specifications.Orders
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification()
        {
            AddInclude(p => p.OrderItems);
            AddOrderBy(p => p.Id);
        }

        public OrderSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.OrderItems);
        }


    }
}
