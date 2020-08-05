using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using ShippingService.Application.Events.External;
using ShippingService.Application.Exceptions;
using ShippingService.Application.Services;
using ShippingService.Core.Entities;
using ShippingService.Core.Repositories;

namespace ShippingService.Application.Commands.Handlers
{
    public class CreateShipmentHandler : ICommandHandler<CreateShipment>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IEventProcessor _eventProcessor;

        public CreateShipmentHandler(IShipmentRepository shipmentRepository, IEventProcessor eventProcessor)
        {
            _shipmentRepository = shipmentRepository;
            _eventProcessor = eventProcessor;
        }
        
        public async Task HandleAsync(CreateShipment command)
        {

            Shipment s = Shipment.Create(command.Id, command.ShipmentName);
            await _shipmentRepository.AddAsync(s);
            await _eventProcessor.ProcessAsync(s.Events);
        }

        private async Task<bool> ExistsShipmentWithGivenId(Guid id)
        {
            return await _shipmentRepository.ExistsAsync(id);
        }
    }
}