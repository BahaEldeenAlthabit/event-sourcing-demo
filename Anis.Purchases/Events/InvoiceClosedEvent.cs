using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class InvoiceClosedEvent : Event<InvoiceClosedData>
    {
        protected InvoiceClosedEvent() { }
        public InvoiceClosedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            InvoiceClosedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
