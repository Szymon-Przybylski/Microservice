using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Events.External
{
    [Message("payments")]
    public class PaymentCompleted : IEvent
    {
        public Guid Id { get; set; }
        public string PaymentName { get; set; }
        
        public PaymentCompleted (Guid id, string paymentName)
        {
            Id = id;
            PaymentName = paymentName;
        }
    }
}