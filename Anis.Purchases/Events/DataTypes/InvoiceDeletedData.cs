using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record InvoiceDeletedData() : IEventData
    {
        public EventType Type => EventType.InvoiceDeleted;
    }
}
