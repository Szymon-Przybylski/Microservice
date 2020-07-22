using MongoDB.Driver;
using ShippingService.Infrastructure.Mongo.Documents;

namespace ShippingService.Infrastructure.Mongo.CollectionProviding.Abstract
{
    public interface IMongoCollectionProvider
    {
        IMongoCollection<ShipmentDocument> ShipmentDocumentCollection();
    }
}