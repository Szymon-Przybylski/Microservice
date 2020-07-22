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
        private readonly IMessageBroker _messageBroker;
        
        public CreateShipmentHandler(IShipmentRepository shipmentRepository, IMessageBroker messageBroker)
        {
            _shipmentRepository = shipmentRepository;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(CreateShipment command)
        {
            /*if (await ExistsShipmentWithGivenId(command.Id))
            {
                throw  new  ShipmentAlreadyExistsException(command.Id);
            }*/

            await _shipmentRepository.AddAsync(Shipment.Create(command.Id, command.ShipmentName));
            await _messageBroker.PublishAsync(new ShipmentCreated(command.Id));
        }

        private async Task<bool> ExistsShipmentWithGivenId(Guid id)
        {
            return await _shipmentRepository.ExistsAsync(id);
        }
    }
}