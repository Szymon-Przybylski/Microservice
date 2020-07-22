using System;
using Convey.CQRS.Events;

namespace ShippingService.Application.Events
{
    public class ShipmentCompleted : IEvent
    {
        public Guid Id { get; set; }
        
        public ShipmentCompleted (Guid id)
        {
            Id = id;
        }
    }
}