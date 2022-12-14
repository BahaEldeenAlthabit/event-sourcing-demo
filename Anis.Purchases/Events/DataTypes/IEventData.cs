using Anis.Purchases.Enums;
using Newtonsoft.Json;

namespace Anis.Purchases.Events.DataTypes
{
    public interface IEventData
    {
        [JsonIgnore]
        EventType Type { get; }
    }
}
