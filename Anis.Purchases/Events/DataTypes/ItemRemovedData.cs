using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record ItemRemovedData(
        string ItemId
    ) : IEventData
    {
        public EventType Type => EventType.ItemRemoved;
    }
}
