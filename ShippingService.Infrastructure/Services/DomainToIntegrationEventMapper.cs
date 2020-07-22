using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Events;
using ShippingService.Application.Services;
using ShippingService.Core.Events.Abstract;
using ShippingService.Core.Events.Concrete;
using ShipmentCreated = ShippingService.Application.Events.External.ShipmentCreated;

namespace ShippingService.Infrastructure.Services
{
    public class DomainToIntegrationEventMapper :IDomainToIntegrationEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events) => events.Select(Map);

        public IEvent Map(IDomainEvent @event) => @event switch
        {
            ShipmentCreated e => new ShipmentCreated(e.Id),
            _ => null
        };
    }
}