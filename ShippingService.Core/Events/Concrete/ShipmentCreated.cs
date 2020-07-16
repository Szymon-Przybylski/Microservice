using ShippingService.Core.Entities;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Core.Events.Concrete
{
    public class ShipmentCreated : IDomainEvent
    {
        public Shipment Shipment { get; }
        
        public ShipmentCreated(Shipment shipment)
        {
            Shipment = shipment;
        }
    }
}