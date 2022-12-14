using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Events
{
    public class ShippingUnconfirmedEvent : Event<ShippingUnconfirmedData>
    {
        protected ShippingUnconfirmedEvent() { }
        public ShippingUnconfirmedEvent(
            Guid aggregateId,
            string userId,
            int sequence,
            ShippingUnconfirmedData data,
            int version = 1
        )
            : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
