using Anis.Purchases.Commands;
using Anis.Purchases.Enums;
using Anis.Purchases.Events;
using System;

namespace Anis.Purchases.Models
{
    public class InvoiceShipment
    {
        public InvoiceShipment(ShipmentAddedEvent @event)
        {
            ShippingId = @event.Data.ShippingId;
            ShippingType = @event.Data.ShippingType;
            Cost = @event.Data.Cost;
            Note = @event.Data.Note;
        }

        public Guid ShippingId { get; private set; }
        public ShippingType ShippingType { get; private set; }
        public decimal Cost { get; private set; }
        public string Note { get; private set; }

        public bool HaveNoChanges(UpdateShipmentCommand command)
            => ShippingId == command.ShippingId
            && ShippingType == command.ShippingType
            && Cost == command.Cost
            && Note == command.Note;

        public void Apply(ShipmentUpdatedEvent @event)
        {
            ShippingId = @event.Data.ShippingId;
            ShippingType = @event.Data.ShippingType;
            Cost = @event.Data.Cost;
            Note = @event.Data.Note;
        }
    }
}
