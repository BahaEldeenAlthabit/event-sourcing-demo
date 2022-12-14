using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record ShippingConfirmedData() : IEventData
    {
        public EventType Type => EventType.ShippingConfirmed;
    }
}
