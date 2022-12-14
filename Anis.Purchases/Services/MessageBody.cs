using System;

namespace Anis.Purchases.Services
{
    public class MessageBody
    {
        public Guid AggregateId { get; set; }
        public int Sequence { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public object Data { get; set; }
        public DateTime DateTime { get; set; }
        public int Version { get; set; }
    }
}
