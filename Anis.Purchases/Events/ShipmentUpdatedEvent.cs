using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ShipmentUpdatedEvent : Event<ShipmentUpdatedData>
    {
        protected ShipmentUpdatedEvent() { }
        public ShipmentUpdatedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ShipmentUpdatedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
