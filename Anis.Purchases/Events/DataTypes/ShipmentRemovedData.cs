using Anis.Purchases.Enums;
using System;

namespace Anis.Purchases.Events.DataTypes
{
    public record ShipmentRemovedData(
        Guid ShippingId
    ) : IEventData
    {
        public EventType Type => EventType.ShipmentRemoved;
    }
}
