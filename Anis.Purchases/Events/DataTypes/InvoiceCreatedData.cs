using Anis.Purchases.Enums;
using System;

namespace Anis.Purchases.Events.DataTypes
{
    public record InvoiceCreatedData(
        string CustomerId,
        string Reference,
        DateTime Deadline,
        string Statement,
        string PaymentNote
    ) : IEventData
    {
        public EventType Type => EventType.InvoiceCreated;
    }
}
