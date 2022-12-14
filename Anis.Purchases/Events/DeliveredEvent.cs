using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class DeliveredEvent : Event<DeliveredData>
    {
        protected DeliveredEvent() { }
        public DeliveredEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            DeliveredData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
