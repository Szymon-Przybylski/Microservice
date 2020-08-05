using System;
using System.Net;
using Newtonsoft.Json.Linq;
using ShippingService.Application.Events.External;
using ShippingService.Application.Services;

namespace ShippingService.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public string GetPaymentData(Guid paymentId)
        {
            String orderId = paymentId.ToString("N");
            String url = $"http://payments/api/payments?orderId={orderId}";
            String orderJsonString = new WebClient().DownloadString(url);
            JObject paymentJson = JObject.Parse(orderJsonString);

            string paymentName = paymentJson["orderId"].ToObject<string>();

            return paymentName;
        }
    }
}