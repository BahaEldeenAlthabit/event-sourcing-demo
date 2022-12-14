using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record InvoiceInfoUpdatedData(
        string Statement,
        string PaymentNote
    ) : IEventData
    {
        public EventType Type => EventType.InvoiceInfoUpdated;
    }
}
