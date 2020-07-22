using System;
using Convey.CQRS.Events;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Core.Events.Concrete
{
    public class ShipmentCreated :IDomainEvent
    {
        public Guid Id { get; set; }
        
        public ShipmentCreated (Guid id)
        {
            Id = id;
        }
    }
}