using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Events.External
{
    [Message("shipment")]
    public class ShipmentCompleted : IEvent
    {
        public Guid Id { get; set; }
        
        public ShipmentCompleted (Guid id)
        {
            Id = id;
        }
    }
}