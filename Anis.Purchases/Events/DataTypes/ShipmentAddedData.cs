using Anis.Purchases.Enums;
using System;

namespace Anis.Purchases.Events.DataTypes
{
    public record ShipmentAddedData(
        Guid ShippingId,
        ShippingType ShippingType,
        decimal Cost,
        string Note
    ) : IEventData
    {
        public EventType Type => EventType.ShipmentAdded;
    }
}
