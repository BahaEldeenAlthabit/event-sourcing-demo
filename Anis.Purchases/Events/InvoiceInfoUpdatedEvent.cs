using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class InvoiceInfoUpdatedEvent : Event<InvoiceInfoUpdatedData>
    {
        protected InvoiceInfoUpdatedEvent() { }
        public InvoiceInfoUpdatedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            InvoiceInfoUpdatedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
