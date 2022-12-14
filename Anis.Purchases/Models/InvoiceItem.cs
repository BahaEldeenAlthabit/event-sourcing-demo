using Anis.Purchases.Commands;
using Anis.Purchases.Events;

namespace Anis.Purchases.Models
{
    public class InvoiceItem
    {
        public InvoiceItem(ItemAddedEvent @event)
        {
            ItemId = @event.Data.ItemId;
            Quantity = @event.Data.Quantity;
            Cost = @event.Data.Cost;
            DamagedQuantity = @event.Data.DamagedQuantity;
            Note = @event.Data.Note;
        }

        public string ItemId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Cost { get; private set; }
        public int DamagedQuantity { get; private set; }
        public string Note { get; private set; }

        public bool HaveNoChanges(UpdateItemCommand command)
            => ItemId == command.ItemId
            && Quantity == command.Quantity
            && Cost == command.Cost
            && Note == command.Note;

        public void Apply(ItemUpdatedEvent @event)
        {
            ItemId = @event.Data.ItemId;
            Cost = @event.Data.Cost;
            Note = @event.Data.Note;
            Quantity = @event.Data.Quantity;
        }

        public void Apply(DamagedQuantityAdjustedEvent @event)
            => DamagedQuantity = @event.Data.DamagedQuantity;
    }
}
