using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record SupplierAssignedData(
        string SupplierId
    ) : IEventData
    {
        public EventType Type => EventType.SupplierAssigned;
    }
}
