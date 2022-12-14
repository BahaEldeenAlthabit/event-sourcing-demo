using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ShipmentAddedEvent : Event<ShipmentAddedData>
    {
        protected ShipmentAddedEvent() { }
        public ShipmentAddedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ShipmentAddedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
