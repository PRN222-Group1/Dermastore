﻿using Dermastore.Application.DTOs.AccountDTOs;
using MediatR;

namespace Dermastore.Application.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public UserDto Customer { get; set; }

        public UpdateCustomerCommand(UserDto customer) 
        {
            Customer = customer; 
        }
    }
}
