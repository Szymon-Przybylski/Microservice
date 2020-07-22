using System;
using Convey.CQRS.Events;

namespace ShippingService.Application.Events
{
    public class ShipmentComplete : IEvent
    {
        public Guid Id { get; set; }
        
        public ShipmentComplete (Guid id)
        {
            Id = id;
        }
    }
}