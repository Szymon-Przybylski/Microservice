using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ShippingService.Core.Entities;
using ShippingService.Infrastructure.Mongo.CollectionProviding.Abstract;
using ShippingService.Infrastructure.Mongo.Documents;

namespace ShippingService.Infrastructure.Mongo.CollectionProviding.Concrete
{
    public class MongoCollectionProvider : IMongoCollectionProvider
    {
        private readonly IMongoClient _mongoClient;
        private readonly string _db;

        public MongoCollectionProvider(IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("mongo").GetSection("connectionString").Value;
            _db = configuration.GetSection("mongo").GetSection("database").Value;
            _mongoClient = new MongoClient(connectionString);
        }
        
        public IMongoCollection<ShipmentDocument> ShipmentDocumentCollection()
        {
            return _mongoClient.GetDatabase(_db).GetCollection<ShipmentDocument>("Shipments");
        }
    }
}