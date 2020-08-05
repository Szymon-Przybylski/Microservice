using System;
using System.Net;
using System.Threading.Tasks;
using Convey.HTTP;
using Newtonsoft.Json.Linq;
using ShippingService.Application.DTOs;
using ShippingService.Application.Events.External;
using ShippingService.Application.Services;

namespace ShippingService.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _url;
        public PaymentService(IHttpClient httpClient, HttpClientOptions httpClientOptions)
        {
            _httpClient = httpClient;
            _url = httpClientOptions.Services["payment"];
        }

        public async Task<PaymentDTO> GetPaymentData(Guid id)
            => await _httpClient.GetAsync<PaymentDTO>($"{_url}/api/payments/{id.ToString()}");
        
    }
}