using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class SupplierChangedEvent : Event<SupplierChangedData>
    {
        protected SupplierChangedEvent() { }
        public SupplierChangedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            SupplierChangedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
