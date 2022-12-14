using Anis.Purchases.Enums;
using System;

namespace Anis.Purchases.Events.DataTypes
{
    public record DeadlineChangedData(
        DateTime Deadline
    ) : IEventData
    {
        public EventType Type => EventType.DeadlineChanged;
    }
}
