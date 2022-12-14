using Anis.Purchases.Commands;
using Anis.Purchases.Enums;
using Anis.Purchases.Events;
using Anis.Purchases.Extensions;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anis.Purchases.Models
{
    public class Invoice : Aggregate<Invoice>
    {
        private Invoice() { }

        public string CustomerId { get; private set; }
        public string Reference { get; private set; }
        public DateTime Deadline { get; private set; }
        public string Statement { get; private set; }
        public string PaymentNote { get; private set; }
        public string SupplierId { get; private set; }
        public InvoiceState State { get; private set; }

        private readonly HashSet<InvoiceItem> _items = new();
        public IReadOnlyCollection<InvoiceItem> Items => _items;

        private readonly HashSet<InvoiceShipment> _shipments = new();
        public IReadOnlyCollection<InvoiceShipment> Shipments => _shipments;

        private readonly HashSet<InvoiceMovement> _movements = new();
        public IReadOnlyCollection<InvoiceMovement> Movements => _movements;


        public static Invoice Create(CreateInvoiceCommand command)
        {
            var @event = command.ToEvent();

            var invoice = new Invoice();

            invoice.ApplyChange(@event);

            return invoice;
        }

        public void UpdateInfo(UpdateInvoiceInfoCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (Statement == command.Statement && PaymentNote == command.PaymentNote) return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void AssignSupplier(AssignSupplierCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.SupplierAssinged) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (SupplierId == command.SupplierId) return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void ChangeSupplier(ChangeSupplierCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.SupplierAssinged) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (SupplierId == command.SupplierId) return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void CancelDelivery(CancelDeliveryCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.Delivered) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void ChangeDeadline(ChangeDeadlineCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.Delivered) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void CloseInvoice(CloseInvoiceCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.Delivered) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void ConfirmShipping(ConfirmShippingCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.SupplierAssinged) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (Items.Count < 3) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void DeleteInvoice(DeleteInvoiceCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void Deliver(DeliverCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void UnconfirmShipping(UnconfirmShippingCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State != InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }


        public void AddItem(AddItemCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (Items.Any(i => i.ItemId == command.ItemId))
                throw new RpcException(new Status(StatusCode.AlreadyExists, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void AddShipment(AddShipmentCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (Shipments.Any(i => (i.ShippingType, i.Cost, i.Note) == (command.ShippingType, command.Cost, command.Note)))
                throw new RpcException(new Status(StatusCode.AlreadyExists, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void AdjustDamagedQuantity(AdjustDamagedQuantityCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            var item = Items.FirstOrDefault(i => i.ItemId == command.ItemId);

            if (item == null) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (item.DamagedQuantity == command.DamagedQuantity)
                return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void UpdateItem(UpdateItemCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var item = Items.FirstOrDefault(i => i.ItemId == command.ItemId);

            if (item == null) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (item.HaveNoChanges(command)) return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void UpdateShipment(UpdateShipmentCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var shipment = Shipments.FirstOrDefault(i => i.ShippingId == command.ShippingId);

            if (shipment == null) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            if (shipment.HaveNoChanges(command)) return;

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void RemoveItem(RemoveItemCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var item = Items.FirstOrDefault(i => i.ItemId == command.ItemId);

            if (item == null) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void RemoveShipment(RemoveShipmentCommand command)
        {
            if (State == InvoiceState.Deleted) throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            if (State >= InvoiceState.ShippingConfirmed) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var shipment = Shipments.FirstOrDefault(i => i.ShippingId == command.ShippingId);

            if (shipment == null) throw new RpcException(new Status(StatusCode.FailedPrecondition, "MESSAGE HERE"));

            var @event = command.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }


        public void Apply(InvoiceCreatedEvent @event)
        {
            CustomerId = @event.Data.CustomerId;
            Reference = @event.Data.Reference;
            Deadline = @event.Data.Deadline;
            Statement = @event.Data.Statement;
            PaymentNote = @event.Data.PaymentNote;
        }

        public void Apply(InvoiceInfoUpdatedEvent @event)
        {
            Statement = @event.Data.Statement;
            PaymentNote = @event.Data.PaymentNote;
        }

        public void Apply(SupplierAssignedEvent @event)
        {
            Statement = @event.Data.SupplierId;
            State = InvoiceState.SupplierAssinged;
        }

        public void Apply(SupplierChangedEvent @event) => Statement = @event.Data.SupplierId;

        public void Apply(DeliveryCancelledEvent @event)
        {
            State = InvoiceState.ShippingConfirmed;
            _movements.Add(new InvoiceMovement(@event));
        }

        public void Apply(DeadlineChangedEvent @event) => Deadline = @event.Data.Deadline;

        public void Apply(InvoiceClosedEvent @event)
        {
            State = InvoiceState.Closed;
            _movements.Add(new InvoiceMovement(@event));
        }

        public void Apply(ShippingConfirmedEvent @event)
        {
            State = InvoiceState.ShippingConfirmed;
            _movements.Add(new InvoiceMovement(@event));
        }

        public void Apply(DeliveredEvent @event)
        {
            State = InvoiceState.Delivered;
            _movements.Add(new InvoiceMovement(@event));
        }

        public void Apply(ShippingUnconfirmedEvent @event)
        {
            State = InvoiceState.SupplierAssinged;
            _movements.Add(new InvoiceMovement(@event));
        }

        public void Apply(InvoiceDeletedEvent @event)
        {
            State = InvoiceState.Deleted;
            Console.WriteLine(@event.Type); // Remove warning
        }

        public void Apply(ItemAddedEvent @event) => _items.Add(new InvoiceItem(@event));

        public void Apply(DamagedQuantityAdjustedEvent @event)
        {
            var item = Items.First(i => i.ItemId == @event.Data.ItemId);
            item.Apply(@event);
        }

        public void Apply(ItemUpdatedEvent @event)
        {
            var item = Items.First(i => i.ItemId == @event.Data.ItemId);
            item.Apply(@event);
        }

        public void Apply(ItemRemovedEvent @event) => _items.RemoveWhere(i => i.ItemId == @event.Data.ItemId);

        public void Apply(ShipmentAddedEvent @event) => _shipments.Add(new InvoiceShipment(@event));

        public void Apply(ShipmentUpdatedEvent @event)
        {
            var shipment = Shipments.First(i => i.ShippingId == @event.Data.ShippingId);
            shipment.Apply(@event);
        }

        public void Apply(ShipmentRemovedEvent @event) => _shipments.RemoveWhere(i => i.ShippingId == @event.Data.ShippingId);
    }
}
