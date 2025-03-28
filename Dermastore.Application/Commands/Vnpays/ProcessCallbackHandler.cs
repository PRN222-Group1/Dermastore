using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Vnpays
{
    public class ProcessCallbackHandler : IRequestHandler<ProcessCallbackCommand, PaymentResult>
    {
        private readonly IVnpayService _vnpayService;
        private readonly IOrderService _orderService;

        public ProcessCallbackHandler(IVnpayService vnpayService,
            IOrderService orderService)
        {
            _vnpayService = vnpayService;
            _orderService = orderService;
        }

        public async Task<PaymentResult> Handle(ProcessCallbackCommand request, CancellationToken cancellationToken)
        {
            var paymentResult = _vnpayService.GetPaymentResult(request.QueryCollection);

            if (paymentResult.IsSuccess)
            {
                int orderId = int.Parse(paymentResult.Description);
                if (orderId <= 0)
                    throw new ArgumentException("Không xác định được OrderId từ dữ liệu thanh toán.");
            }

            return paymentResult;
        }
    }
}
