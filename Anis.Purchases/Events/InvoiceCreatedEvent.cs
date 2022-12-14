using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class InvoiceCreatedEvent : Event<InvoiceCreatedData>
    {
        protected InvoiceCreatedEvent() { }
        public InvoiceCreatedEvent(
            Guid aggregateId,
            string userId,
            InvoiceCreatedData data,
            int version = 1
        ) : base(aggregateId, sequence: 1, userId, data, version)
        {
        }
    }
}
