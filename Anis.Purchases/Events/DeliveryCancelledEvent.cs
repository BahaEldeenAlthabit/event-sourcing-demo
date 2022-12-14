using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class DeliveryCancelledEvent : Event<DeliveryCancelledData>
    {
        protected DeliveryCancelledEvent() { }
        public DeliveryCancelledEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            DeliveryCancelledData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
