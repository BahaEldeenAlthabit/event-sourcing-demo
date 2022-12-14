using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class InvoiceDeletedEvent : Event<InvoiceDeletedData>
    {
        protected InvoiceDeletedEvent() { }
        public InvoiceDeletedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            InvoiceDeletedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
