using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Events.External
{
    [Message("payments")]
    public class PaymentCompleted : IEvent
    {
        public Guid PaymentId { get; set; }

        public PaymentCompleted (Guid id)
        {
            PaymentId = id;
        }
    }
}