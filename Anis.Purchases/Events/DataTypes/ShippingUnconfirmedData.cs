using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record ShippingUnconfirmedData(
        string Note
    ) : IEventData
    {
        public EventType Type => EventType.ShippingUnconfirmed;
    }
}
