using System.Threading.Tasks;
using Convey.CQRS.Queries;
using MongoDB.Driver;
using ShippingService.Application.DTOs;
using ShippingService.Application.Queries;
using ShippingService.Infrastructure.Mongo.CollectionProviding.Abstract;
using ShippingService.Infrastructure.Mongo.Documents;

namespace ShippingService.Infrastructure.Mongo.Queries.Handlers
{
    public class GetShipmentHandler : IQueryHandler<GetShipment, ShipmentDTO>
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetShipmentHandler(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }
        
        public async Task<ShipmentDTO> HandleAsync(GetShipment query)
        {
            ShipmentDocument resource = await _mongoCollectionProvider.ShipmentDocumentCollection()
                .Find(x => x.Id == query.ShipmentId)
                .SingleOrDefaultAsync();
            if (resource is null)
            {
                return null;
            }

            return new ShipmentDTO
            {
                Id = resource.Id,
                ShipmentName = resource.ShipmentName
            };
        }
    }
}