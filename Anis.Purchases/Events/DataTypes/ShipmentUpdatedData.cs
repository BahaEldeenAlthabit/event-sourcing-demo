using Anis.Purchases.Enums;
using System;

namespace Anis.Purchases.Events.DataTypes
{
    public record ShipmentUpdatedData(
        Guid ShippingId,
        ShippingType ShippingType,
        decimal Cost,
        string Note
    ) : IEventData
    {
        public EventType Type => EventType.ShipmentUpdated;
    }
}
