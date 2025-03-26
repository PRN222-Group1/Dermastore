using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Helpers;
using Dermastore.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Dermastore.Application.Commands.Vnpays
{
    public class CreatePaymentUrlHandler : IRequestHandler<CreatePaymentUrlCommand, string>
    {
        private readonly IVnpayService _vnpayService;
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreatePaymentUrlHandler(IVnpayService vnpayService, IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _vnpayService = vnpayService;
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(CreatePaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(request.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            var ipAddress = NetworkHelper.GetIpAddress(_httpContextAccessor.HttpContext);

            var paymentRequest = new PaymentRequest
            {
                PaymentId = DateTime.Now.Ticks,
                Money = Convert.ToDouble(order.SubTotal),
                Description = $"{order.Id}",
                IpAddress = ipAddress,
                BankCode = BankCode.ANY,
                CreatedDate = DateTime.Now,
                Currency = Currency.VND,
                Language = DisplayLanguage.Vietnamese
            };

            var paymentUrl = _vnpayService.GetPaymentUrl(paymentRequest);

            if (string.IsNullOrWhiteSpace(paymentUrl))
            {
                throw new Exception("Failed to generate payment URL.");
            }
            return paymentUrl;
        }
    }
}
