using System;
using ShippingService.Application.Events.External;

namespace ShippingService.Application.Services
{
    public interface IPaymentService
    {
        public string GetPaymentData(Guid paymentId);
    }
}