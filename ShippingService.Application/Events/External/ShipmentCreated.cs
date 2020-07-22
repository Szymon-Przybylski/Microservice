using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Events.External
{
    [Message("shipment")]
    public class ShipmentCreated : IEvent
    {
        public Guid Id { get; set; }
        
        public ShipmentCreated (Guid id)
        {
            Id = id;
        }
    }
}