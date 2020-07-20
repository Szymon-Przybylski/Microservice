using System.Collections.Generic;
using System.Threading.Tasks;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}