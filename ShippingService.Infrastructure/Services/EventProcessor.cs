using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShippingService.Application.Events;
using ShippingService.Application.Services;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Infrastructure.Services
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMessageBroker _messageBroker;
        private readonly IDomainToIntegrationEventMapper _eventMapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<IEventProcessor> _logger;

        public EventProcessor(ILogger<IEventProcessor> logger, IServiceScopeFactory serviceScopeFactory, IDomainToIntegrationEventMapper eventMapper, IMessageBroker messageBroker)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
        }
        
        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null)
            {
                return;;
            }

            List<IEvent> integrationEvents = await HandleDomainEventsAsync(events);
            if (!integrationEvents.Any())
            {
                return;
            }

            await _messageBroker.PublishAsync(integrationEvents);
        }

        private async Task<List<IEvent>> HandleDomainEventsAsync(IEnumerable<IDomainEvent> events)
        {
            List<IEvent> integrationEvents = new List<IEvent>();
            using var scope = _serviceScopeFactory.CreateScope();
            foreach (IDomainEvent eve in events)
            {
                var eventType = eve.GetType();
                _logger.LogTrace($"Handling a domain event: {eventType.Name}");
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType();
                dynamic handlers = scope.ServiceProvider.GetService(handlerType);
                foreach (dynamic handler in handlers)
                {
                    await handler.HandlerAsync((dynamic) eve);
                }

                IEvent integrationEvent = _eventMapper.Map(eve);
                if (integrationEvent is null)
                {
                    continue;
                }
                
                integrationEvents.Add(integrationEvent);
                
            }

            return integrationEvents;
        }
    }
}