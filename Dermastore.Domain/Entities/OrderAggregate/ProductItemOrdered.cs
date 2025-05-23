﻿namespace Dermastore.Domain.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string ImageUrl { get; set; }
    }
}
