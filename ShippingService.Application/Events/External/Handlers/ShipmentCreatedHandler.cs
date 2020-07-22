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
    public class ShipmentCreatedHandler : IEventHandler<ShipmentCreated>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventProcessor _eventProcessor;

        public ShipmentCreatedHandler(IShipmentRepository shipmentRepository, IMessageBroker messageBroker, IEventProcessor eventProcessor)
        {
            _shipmentRepository = shipmentRepository;
            _messageBroker = messageBroker;
            _eventProcessor = eventProcessor;
        }
        public Task HandleAsync(ShipmentCreated @event)
        {
            Console.WriteLine("Nie robie głupot tylko sprawdzam czy działą komunikacja");
            return Task.CompletedTask;

        }
    }
}