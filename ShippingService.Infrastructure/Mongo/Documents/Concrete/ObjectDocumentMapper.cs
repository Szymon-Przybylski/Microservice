using ShippingService.Core.Entities;
using ShippingService.Infrastructure.Mongo.Documents.Abstract;

namespace ShippingService.Infrastructure.Mongo.Documents.Concrete
{
    public class ObjectDocumentMapper : IObjectDocumentMapper
    {
        public Shipment Convert(ShipmentDocument shipmentDocument)
        {
            return shipmentDocument is null ? null : new Shipment(shipmentDocument.Id, shipmentDocument.ShipmentName);
        }

        public ShipmentDocument Convert(Shipment shipment)
        {
            return shipment is null
                ? null
                : new ShipmentDocument
                {
                    Id = shipment.Id,
                    ShipmentName = shipment.ShipmentName
                };
        }
    }
}