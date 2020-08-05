using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.HTTP;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using ShippingService.Application.Commands;
using ShippingService.Application.Services;
using ShippingService.Core.Entities;
using ShippingService.Core.Repositories;

namespace ShippingService.Application.Events.External.Handlers
{
    public class PaymentCompletedHandler : IEventHandler<PaymentCompleted>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IEventProcessor _eventProcessor;
        public PaymentCompletedHandler(IEventProcessor eventProcessor,
            IShipmentRepository shipmentRepository, IPaymentService paymentService)
        {
            _shipmentRepository = shipmentRepository;
            _paymentService = paymentService;
            _eventProcessor = eventProcessor;
        }
        public async Task HandleAsync(PaymentCompleted @event)
        {
            string shipmentName = _paymentService.GetPaymentData(@event.Id);
            Shipment s = Shipment.Create(@event.Id, shipmentName );
            

            await _shipmentRepository.AddAsync(s);
            await _eventProcessor.ProcessAsync(s.Events);
        }
    }
}