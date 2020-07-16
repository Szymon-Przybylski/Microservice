using System.Threading.Tasks;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Application.Events
{
    public interface IDomainEventHandler<in T> where T : class, IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}