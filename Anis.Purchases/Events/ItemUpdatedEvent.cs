using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ItemUpdatedEvent : Event<ItemUpdatedData>
    {
        protected ItemUpdatedEvent() { }
        public ItemUpdatedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ItemUpdatedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
