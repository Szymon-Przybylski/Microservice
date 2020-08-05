using System;
using System.Threading.Tasks;
using ShippingService.Application.DTOs;
using ShippingService.Application.Events.External;

namespace ShippingService.Application.Services
{
    public interface IPaymentService
    {
        public Task<PaymentDTO> GetPaymentData(Guid paymentId);
    }
}