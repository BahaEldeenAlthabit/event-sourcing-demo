using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record ItemAddedData(
        string ItemId,
        int Quantity,
        decimal Cost,
        string Note,
        int DamagedQuantity
    ) : IEventData
    {
        public EventType Type => EventType.ItemAdded;
    }
}
