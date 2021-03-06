﻿using System;
using ShippingService.Core.Events.Concrete;

namespace ShippingService.Core.Entities
{
    public class Shipment : AggregareRoot
    {
        public string ShipmentName { get; }
        
        public Shipment(Guid id, string shipmentName, int version = 0)
        {
            Id = id;
            ShipmentName = shipmentName;
            Version = version;
        }

        public static Shipment Create(Guid id, string shipmentName)
        {
            if (string.IsNullOrWhiteSpace(shipmentName))
            {
                throw new NotImplementedException();
            }
            Shipment shipment = new Shipment(id, shipmentName);
            shipment.AddEvent(new ShipmentCreated(shipment.Id));
            
            return shipment;
        }
    }
}