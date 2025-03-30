using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dermastore.Application.Commands.Vnpays
{
    public class ProcessCallbackCommand : IRequest<int>
    {
        public IQueryCollection QueryCollection { get; }
        public ProcessCallbackCommand(IQueryCollection queryCollection)
        {
            QueryCollection = queryCollection;
        }
    }

}
