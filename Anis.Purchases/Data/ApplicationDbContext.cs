using Anis.Purchases.Data.Configurations;
using Anis.Purchases.Data.Entities;
using Anis.Purchases.Enums;
using Anis.Purchases.Events;
using Anis.Purchases.Events.DataTypes;
using Anis.Purchases.Models;
using Anis.Purchases.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Anis.Purchases.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ServiceBusPublisher _publisher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ServiceBusPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<DamagedQuantityAdjustedEvent, DamagedQuantityAdjustedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<DeadlineChangedEvent, DeadlineChangedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<DeliveredEvent, DeliveredData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<DeliveryCancelledEvent, DeliveryCancelledData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvoiceClosedEvent, InvoiceClosedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvoiceCreatedEvent, InvoiceCreatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvoiceDeletedEvent, InvoiceDeletedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvoiceInfoUpdatedEvent, InvoiceInfoUpdatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ItemAddedEvent, ItemAddedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ItemRemovedEvent, ItemRemovedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ItemUpdatedEvent, ItemUpdatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ShipmentAddedEvent, ShipmentAddedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ShipmentRemovedEvent, ShipmentRemovedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ShipmentUpdatedEvent, ShipmentUpdatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ShippingConfirmedEvent, ShippingConfirmedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<ShippingUnconfirmedEvent, ShippingUnconfirmedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SupplierAssignedEvent, SupplierAssignedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SupplierChangedEvent, SupplierChangedData>());
            modelBuilder.ApplyConfiguration(new UniqueReferenceConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UniqueReference> UniqueReferences { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<Event> EventStore { get; set; }


        public async Task CommitNewEventsAsync(Invoice invoice)
        {
            var newEvents = invoice.GetUncommittedEvents();

            await EventStore.AddRangeAsync(newEvents);

            var messages = OutboxMessage.ToManyMessages(newEvents);

            await OutboxMessages.AddRangeAsync(messages);

            foreach (var @event in newEvents)
            {
                if (@event.Type == EventType.InvoiceCreated)
                    await UniqueReferences.AddAsync(new UniqueReference(invoice));
            }

            await SaveChangesAsync();


            invoice.MarkChangesAsCommitted();

            await _publisher.PublishAsync(messages);
        }
    }
}
