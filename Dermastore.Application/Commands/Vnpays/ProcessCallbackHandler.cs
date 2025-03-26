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

        public ProcessCallbackHandler(IOrderService orderService, IVnpayService vnpayService)
        {
            _orderService = orderService;
            _vnpayService = vnpayService;
        }

        public async Task<PaymentResult> Handle(ProcessCallbackCommand request, CancellationToken cancellationToken)
        {
            var paymentResult = _vnpayService.GetPaymentResult(request.Query);

            if (paymentResult.IsSuccess)
            {
                if (!int.TryParse(paymentResult.Description, out int orderId) || orderId <= 0)
                {
                    throw new InvalidOperationException("Không xác định được OrderId từ dữ liệu thanh toán.");
                }

                await _orderService.ChangeOrderStatus(orderId, OrderStatus.Complete);
            }
            return paymentResult;
        }
    }
}
