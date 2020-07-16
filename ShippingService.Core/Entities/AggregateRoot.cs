﻿using System.Collections.Generic;
using System.Linq;
using ShippingService.Core.Events.Abstract;

namespace ShippingService.Core.Entities
{
    public class AggregareRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;
        public AggregateId Id { get; protected set; }
        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any())
            {
                Version += 1;
            }
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}