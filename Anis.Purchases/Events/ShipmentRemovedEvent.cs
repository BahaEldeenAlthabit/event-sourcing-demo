using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ShipmentRemovedEvent : Event<ShipmentRemovedData>
    {
        protected ShipmentRemovedEvent() { }
        public ShipmentRemovedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ShipmentRemovedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
