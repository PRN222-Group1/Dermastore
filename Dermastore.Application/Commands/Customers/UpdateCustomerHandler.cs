using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Customers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateCustomerHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userService.GetUserByIdAsync(request.Customer.Id);
            if (customer == null)
            {
                return false;
            }

            customer.UpdateFromDto(request.Customer);

            var result = await _userService.UpdateUserAsync(customer);
            return result.Succeeded ? true : false;
        }
    }
}
