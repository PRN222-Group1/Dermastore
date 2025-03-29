﻿using Dermastore.Application.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<IReadOnlyList<OrderDto>>
    {
    }
}
