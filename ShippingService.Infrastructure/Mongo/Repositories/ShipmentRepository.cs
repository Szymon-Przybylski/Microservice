using System;
using System.Threading.Tasks;
using ShippingService.Core.Entities;
using ShippingService.Core.Repositories;
using ShippingService.Infrastructure.Mongo.CollectionProviding.Abstract;
using ShippingService.Infrastructure.Mongo.Documents.Abstract;

namespace ShippingService.Infrastructure.Mongo.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly IObjectDocumentMapper _objectDocumentMapper;
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public ShipmentRepository(IObjectDocumentMapper objectDocumentMapper,
            IMongoCollectionProvider mongoCollectionProvider)
        {
            _objectDocumentMapper = objectDocumentMapper;
            _mongoCollectionProvider = mongoCollectionProvider;
        }
        public async Task<Shipment> AddAsync(Shipment shipment)
        {
            await _mongoCollectionProvider.ShipmentDocumentCollection()
                .InsertOneAsync(_objectDocumentMapper.Convert(shipment));
            return shipment;
        }

        public Task UpdateAsync(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid shipmentId)
        {
            throw new NotImplementedException();
        }
    }
}