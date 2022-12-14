using Anis.Purchases.InvoicesProto.V1;
using Anis.Purchases.Models;
using Google.Protobuf.WellKnownTypes;

namespace Anis.Purchases.Extensions
{
    public static class ModelExtensions
    {
        public static InvoiceOutput ToOutput(this Invoice invoice)
            => new()
            {
                CustomerId = invoice.CustomerId,
                Deadline = invoice.Deadline.ToTimestamp(),
                Id = invoice.Id.ToString(),
                PaymentNote = invoice.PaymentNote,
                Statement = invoice.Statement,
                State = invoice.State.ToProtoEnum(),
                Reference = invoice.Reference,
            };
    }
}
