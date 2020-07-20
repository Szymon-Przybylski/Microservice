using System;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Convey.MessageBrokers.Outbox;

namespace ShippingService.Infrastructure.OutboxDecorators
{
    public class OutboxEventHandlerDecorator<T> : IEventHandler<T> where T : class, IEvent
    {
        private readonly IEventHandler<T> _handler;
        private readonly IMessageOutbox _messageOutbox;
        private readonly string _messageId;
        private readonly bool _enabled;

        public OutboxEventHandlerDecorator(IEventHandler<T> handler, IMessageOutbox messageOutbox,
            OutboxOptions outboxOptions,
            IMessagePropertiesAccessor messagePropertiesAccessor)
        {
            _handler = handler;
            _messageOutbox = messageOutbox;
            _enabled = outboxOptions.Enabled;
            IMessageProperties props = messagePropertiesAccessor.MessageProperties;
            _messageId = string.IsNullOrWhiteSpace(props?.MessageId) ? Guid.NewGuid().ToString("N") : props.MessageId;
        }

        public Task HandleAsync(T command)
            => _enabled
                ? _messageOutbox.HandleAsync(_messageId, () => _handler.HandleAsync(command))
                : _handler.HandleAsync(command);
    }
}