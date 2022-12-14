using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record DeliveredData(
        string DeliveryNote
    ) : IEventData
    {
        public EventType Type => EventType.Delivered;
    }
}
