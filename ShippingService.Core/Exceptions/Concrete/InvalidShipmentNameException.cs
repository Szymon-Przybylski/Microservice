using ShippingService.Core.Exceptions.Abstract;

namespace ShippingService.Core.Exceptions.Concrete
{
    public class InvalidShipmentNameException : DomainException
    {
        public InvalidShipmentNameException(string message) : base(message)
        {
        }

        public override string Code => _code;
        private const string _code = "Shipment name cannot be null";
    }
}