using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using ShippingService.Application.Commands;
using ShippingService.Application.Services;
using ShippingService.Core.Entities;
using ShippingService.Core.Repositories;

namespace ShippingService.Application.Events.External.Handlers
{
    public class ShipmentCompletedHandler : IEventHandler<ShipmentCompleted>
    {

        public ShipmentCompletedHandler()
        {
        }
        public Task HandleAsync(ShipmentCompleted @event)
        {
            Console.WriteLine("Nie robie głupot tylko sprawdzam czy działa komunikacja");
            return Task.CompletedTask;

        }
    }
}