using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class DeadlineChangedEvent : Event<DeadlineChangedData>
    {
        protected DeadlineChangedEvent() { }
        public DeadlineChangedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            DeadlineChangedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
