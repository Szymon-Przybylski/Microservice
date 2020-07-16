using System;
using System.Net;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Newtonsoft.Json.Linq;
using ShippingService.Core.Entities;

namespace ShippingService.Application.Events.External.Handlers
{
    public class ShipmentCreatedHandler : IEventHandler<ShipmentCreated>
    {
        public Task HandleAsync(ShipmentCreated @event)
        {

            String paymentId = @event.Id.ToString("N");
            String url = $"http://localhost:5003/api/payments{paymentId}";
            String paymentJsonString  = new WebClient().DownloadString(url);
            JObject paymentJson = JObject.Parse(paymentJsonString);
            
            string[] products = paymentJson["product"].ToObject<string[]>();

            string separator = "\r\n";
            string shipmentName = String.Join(separator, products);

            Shipment.Create(@event.Id, shipmentName);
            
            return Task.CompletedTask;
        }
    }
}