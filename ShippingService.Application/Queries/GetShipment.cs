using System;
using Convey.CQRS.Queries;
using ShippingService.Application.DTOs;

namespace ShippingService.Application.Queries
{
    public class GetShipment :IQuery<ShipmentDTO>
    {
        public Guid ShipmentId { get; set; }
    }
}