using System;

namespace ShippingService.Infrastructure.Mongo.Documents
{
    public class ShipmentDocument
    {
        public Guid Id { get; set; }
        public string ShipmentName { get; set; }
    }
}