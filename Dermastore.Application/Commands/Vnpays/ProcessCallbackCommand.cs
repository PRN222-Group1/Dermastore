using Dermastore.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Vnpays
{
    public class ProcessCallbackCommand : IRequest<PaymentResult>
    {
        public IQueryCollection QueryCollection { get; }
        public ProcessCallbackCommand(IQueryCollection queryCollection)
        {
            QueryCollection = queryCollection;
        }
    }

}
