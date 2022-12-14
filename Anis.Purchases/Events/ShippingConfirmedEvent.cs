using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ShippingConfirmedEvent : Event<ShippingConfirmedData>
    {
        protected ShippingConfirmedEvent() { }
        public ShippingConfirmedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ShippingConfirmedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
