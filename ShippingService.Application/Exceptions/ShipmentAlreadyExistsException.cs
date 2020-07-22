using System;

namespace ShippingService.Application.Exceptions
{
    public class ShipmentAlreadyExistsException : AppException
    {
        public Guid ShipmentId { get; }
        
        public ShipmentAlreadyExistsException(Guid shipmentId) : base($"Shipment with id: {shipmentId.ToString()}")
        {
            ShipmentId = shipmentId;
        }

        public override string Code => "Shipment already exists";
    }
}