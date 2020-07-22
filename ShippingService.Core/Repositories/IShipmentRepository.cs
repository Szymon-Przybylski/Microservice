using System;
using System.Threading.Tasks;
using ShippingService.Core.Entities;

namespace ShippingService.Core.Repositories
{
    public interface IShipmentRepository
    {
        Task<Shipment> AddAsync(Shipment shipment);
        Task UpdateAsync(Shipment shipment);
        Task DeleteAsync(Shipment shipment);
        Task<bool> ExistsAsync(Guid shipmentId);
    }
}