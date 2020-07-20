using System.Collections.Generic;
using Convey.CQRS.Events;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Services
{
    public interface IDomainToIntegrationEventMapper
    {
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
        IEvent Map(IDomainEvent @event);
    }
}