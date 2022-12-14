using Anis.Purchases.Enums;
using Anis.Purchases.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anis.Purchases.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasIndex(e => new { e.AggregateId, e.Sequence }).IsUnique();

            builder.Property(e => e.UserId)
                .HasMaxLength(128);

            builder.Property(e => e.Type)
                .HasMaxLength(128)
                .HasConversion<string>();

            builder.HasDiscriminator(e => e.Type)
                .HasValue<DamagedQuantityAdjustedEvent>(EventType.DamagedQuantityAdjusted)
                .HasValue<DeadlineChangedEvent>(EventType.DeadlineChanged)
                .HasValue<DeliveredEvent>(EventType.Delivered)
                .HasValue<DeliveryCancelledEvent>(EventType.DeliveryCancelled)
                .HasValue<InvoiceClosedEvent>(EventType.InvoiceClosed)
                .HasValue<InvoiceCreatedEvent>(EventType.InvoiceCreated)
                .HasValue<InvoiceDeletedEvent>(EventType.InvoiceDeleted)
                .HasValue<InvoiceInfoUpdatedEvent>(EventType.InvoiceInfoUpdated)
                .HasValue<ItemAddedEvent>(EventType.ItemAdded)
                .HasValue<ItemRemovedEvent>(EventType.ItemRemoved)
                .HasValue<ItemUpdatedEvent>(EventType.ItemUpdated)
                .HasValue<ShipmentAddedEvent>(EventType.ShipmentAdded)
                .HasValue<ShipmentRemovedEvent>(EventType.ShipmentRemoved)
                .HasValue<ShipmentUpdatedEvent>(EventType.ShipmentUpdated)
                .HasValue<ShippingConfirmedEvent>(EventType.ShippingConfirmed)
                .HasValue<ShippingUnconfirmedEvent>(EventType.ShippingUnconfirmed)
                .HasValue<SupplierAssignedEvent>(EventType.SupplierAssigned)
                .HasValue<SupplierChangedEvent>(EventType.SupplierChanged);
        }
    }
}
