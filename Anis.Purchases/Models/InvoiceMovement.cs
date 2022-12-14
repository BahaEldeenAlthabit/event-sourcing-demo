using Anis.Purchases.Enums;
using Anis.Purchases.Events;
using System;

namespace Anis.Purchases.Models
{
    public class InvoiceMovement
    {
        public InvoiceMovement(DeliveryCancelledEvent @event)
        {
            Type = MovementType.CancelDelivery;
            DateTime = @event.DateTime;
            Note = @event.Data.CancellationNote;
        }

        public InvoiceMovement(InvoiceClosedEvent @event)
        {
            Type = MovementType.Close;
            DateTime = @event.DateTime;
        }

        public InvoiceMovement(ShippingConfirmedEvent @event)
        {
            Type = MovementType.ConfirmShipping;
            DateTime = @event.DateTime;
        }

        public InvoiceMovement(DeliveredEvent @event)
        {
            Type = MovementType.ConfirmShipping;
            DateTime = @event.DateTime;
            Note = @event.Data.DeliveryNote;
        }

        public InvoiceMovement(ShippingUnconfirmedEvent @event)
        {
            Type = MovementType.ConfirmShipping;
            DateTime = @event.DateTime;
            Note = @event.Data.Note;
        }

        public MovementType Type { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Note { get; private set; }
    }
}
