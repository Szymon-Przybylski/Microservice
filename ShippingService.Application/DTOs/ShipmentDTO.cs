using System;

namespace ShippingService.Application.DTOs
{
    public class ShipmentDTO
    {
        public Guid Id { get; set; }
        public string ShipmentName { get; set; }
    }
}