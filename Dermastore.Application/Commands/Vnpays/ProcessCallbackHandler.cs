using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
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
        private readonly IGenericRepository<Product> _productRepo;

        public ProcessCallbackHandler(IVnpayService vnpayService,
            IOrderService orderService, IConfiguration configuration, 
            IUserService userService, IGenericRepository<Membership> membershipRepo, 
            IGenericRepository<Product> productRepo)
        {
            _orderService = orderService;
            _vnpayService = vnpayService;
            _configuration = configuration;
            _userService = userService;
            _membershipRepo = membershipRepo;
            _productRepo = productRepo;
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
                await OnPaymentSuccessUpdate(order);

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

        private async Task OnPaymentSuccessUpdate(Order order)
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

            // Update Product's Quantity
            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.Price < 0) continue;
                var productSpec = new ProductSpecification(orderItem.ItemOrdered.ProductId);
                var product = await _productRepo.GetEntityWithSpec(productSpec);

                product.Quantity = product.Quantity - orderItem.Quantity;

                if (product.Quantity <= 0)
                {
                    product.Quantity = 0;
                    product.Status = ProductStatus.OutOfStock;
                }

                _productRepo.Update(product);
                var result = await _productRepo.SaveAllAsync();

                if (!result)
                {
                    throw new ArgumentException("Failed to update product");
                }
            }
        }
    }
}
