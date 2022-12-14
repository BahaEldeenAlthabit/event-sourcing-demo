using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record SupplierChangedData(
        string SupplierId
    ) : IEventData
    {
        public EventType Type => EventType.SupplierChanged;
    }
}
