using System;
using Convey.CQRS.Commands;

namespace ShippingService.Application.Commands
{
    public class CreateShipment : ICommand
    {
        public Guid Id { get; }
        public string ShipmentName { get; }

        public CreateShipment(Guid id, string shipmentName)
        {
            Id = id;
            ShipmentName = shipmentName;
        }
    }
}