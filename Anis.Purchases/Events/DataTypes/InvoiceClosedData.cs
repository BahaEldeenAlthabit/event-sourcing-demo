using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record InvoiceClosedData() : IEventData
    {
        public EventType Type => EventType.InvoiceClosed;
    }
}
