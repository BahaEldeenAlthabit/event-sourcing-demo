using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ItemAddedEvent : Event<ItemAddedData>
    {
        protected ItemAddedEvent() { }
        public ItemAddedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ItemAddedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
