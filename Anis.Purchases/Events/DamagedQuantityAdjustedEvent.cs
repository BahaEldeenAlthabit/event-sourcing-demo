using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class DamagedQuantityAdjustedEvent : Event<DamagedQuantityAdjustedData>
    {
        protected DamagedQuantityAdjustedEvent() { }
        public DamagedQuantityAdjustedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            DamagedQuantityAdjustedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
