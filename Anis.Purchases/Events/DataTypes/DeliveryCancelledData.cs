using Anis.Purchases.Enums;

namespace Anis.Purchases.Events.DataTypes
{
    public record DeliveryCancelledData(
        string CancellationNote
    ) : IEventData
    {
        public EventType Type => EventType.DeliveryCancelled;
    }
}
