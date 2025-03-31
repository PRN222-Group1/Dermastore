using MediatR;
using Dermastore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dermastore.Domain.Helpers;
using Dermastore.Domain.Models;
using Dermastore.Domain.Enums;

namespace Dermastore.Application.Commands.Vnpays
{
    public class CreatePaymentUrlHandler : IRequestHandler<CreatePaymentUrlCommand, string>
    {
        private readonly IVnpayService _vnpayService;
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CreatePaymentUrlHandler(IOrderService orderService, IHttpContextAccessor httpContextAccessor, IVnpayService vnpayService, IConfiguration configuration)
        {

            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _vnpayService = vnpayService;
            _vnpayService.Initialize(_configuration["Vnpay:TmnCode"], _configuration["Vnpay:HashSecret"], _configuration["Vnpay:BaseUrl"], _configuration["Vnpay:ReturnUrl"]);
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
                    Money = Convert.ToDouble(order.GetTotal()),
                    Description = $"{order.Id}",
                    IpAddress = ipAddress,
                    BankCode = BankCode.ANY,
                    CreatedDate = DateTime.Now,
                    Currency = Currency.VND,
                    Language = DisplayLanguage.Vietnamese
                };

                var paymentUrl = _vnpayService.GetPaymentUrl(paymentRequest);
                return paymentUrl;
            }
            
        }
    }

