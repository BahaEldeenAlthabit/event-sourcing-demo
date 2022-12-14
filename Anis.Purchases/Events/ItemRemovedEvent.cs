using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ItemRemovedEvent : Event<ItemRemovedData>
    {
        protected ItemRemovedEvent() { }
        public ItemRemovedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ItemRemovedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
