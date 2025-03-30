using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dermastore.Application.Commands.Vnpays
{
    public class ProcessCallbackHandler : IRequestHandler<ProcessCallbackCommand, int>
    {
        private readonly IVnpayService _vnpayService;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IGenericRepository<Membership> _membershipRepo;

        public ProcessCallbackHandler(IVnpayService vnpayService,
            IOrderService orderService, IConfiguration configuration, 
            IUserService userService, IGenericRepository<Membership> membershipRepo)
        {
            _orderService = orderService;
            _vnpayService = vnpayService;
            _configuration = configuration;
            _userService = userService;
            _membershipRepo = membershipRepo;
            _vnpayService.Initialize(_configuration["Vnpay:TmnCode"], _configuration["Vnpay:HashSecret"], _configuration["Vnpay:BaseUrl"], _configuration["Vnpay:ReturnUrl"]);

        }

        public async Task<int> Handle(ProcessCallbackCommand request, CancellationToken cancellationToken)
        {
            var paymentResult = _vnpayService.GetPaymentResult(request.QueryCollection);

            // Get order to update status
            int orderId = int.Parse(paymentResult.Description);
            var order = await _orderService.GetOrderById(orderId);

            if (paymentResult.IsSuccess)
            {
                // Update Customer Membership status
                var point = (int)order.GetTotal() / 10000;
                var customer = await _userService.GetUserByIdAsync(order.UserId);
                customer.Point += point;
                var memberships = await _membershipRepo.ListAllAsync();
                var sortedMemberships = memberships.OrderBy(m => m.MinPoint);

                // Find the next Membership status the customer achieved based on loyalty points.
                foreach (var membership in sortedMemberships)
                {
                    if (customer.Point >= membership.MinPoint)
                    {
                        customer.MembershipId = membership.Id;
                    }
                    else break;
                }

                var userResult = await _userService.UpdateUserAsync(customer);

                if (!userResult.Succeeded)
                {
                    throw new ArgumentException("Failed to upgrade user membership");
                }

                order.Status = OrderStatus.Completed;

                if (orderId <= 0)
                    throw new ArgumentException("Cannot find order");
            }
            else
            {
                order.Status = OrderStatus.Cancelled;
            }

            // Update status
            var result = await _orderService.UpdateOrder(order);

            return paymentResult.IsSuccess ? result : -1;
        }
    }
}
