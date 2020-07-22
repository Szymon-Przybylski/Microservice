using ShippingService.Core.Entities;

namespace ShippingService.Infrastructure.Mongo.Documents.Abstract
{
    public interface IObjectDocumentMapper
    {
        Shipment Convert(ShipmentDocument shipmentDocument);
        ShipmentDocument Convert(Shipment shipment);
    }
}