using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record DamagedQuantityAdjustedData(
        string ItemId,
        int DamagedQuantity
    ) : IEventData
    {
        public EventType Type => EventType.DamagedQuantityAdjusted;
    }
}
