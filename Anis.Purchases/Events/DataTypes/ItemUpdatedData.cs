using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record ItemUpdatedData(
        string ItemId,
        int Quantity,
        decimal Cost,
        string Note
    ) : IEventData
    {
        public EventType Type => EventType.ItemUpdated;
    }
}
