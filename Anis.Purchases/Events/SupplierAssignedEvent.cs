using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class SupplierAssignedEvent : Event<SupplierAssignedData>
    {
        protected SupplierAssignedEvent() { }
        public SupplierAssignedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            SupplierAssignedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
