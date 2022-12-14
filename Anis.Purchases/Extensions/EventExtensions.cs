using Anis.Purchases.Commands;
using Anis.Purchases.Events;
using Anis.Purchases.Events.DataTypes;
using System;

namespace Anis.Purchases.Extensions
{
    public static class EventExtensions
    {
        public static InvoiceCreatedEvent ToEvent(this CreateInvoiceCommand command)
            => new(
                aggregateId: Guid.NewGuid(),
                userId: command.UserId,
                data: new InvoiceCreatedData(
                    CustomerId: command.CustomerId,
                    Reference: command.Reference,
                    Deadline: command.Deadline,
                    Statement: command.Statement,
                    PaymentNote: command.PaymentNote
                )
            );

        public static InvoiceInfoUpdatedEvent ToEvent(this UpdateInvoiceInfoCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new InvoiceInfoUpdatedData(
                    Statement: command.Statement,
                    PaymentNote: command.PaymentNote
                )
            );

        public static SupplierAssignedEvent ToEvent(this AssignSupplierCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new SupplierAssignedData(command.SupplierId)
            );

        public static SupplierChangedEvent ToEvent(this ChangeSupplierCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new SupplierChangedData(
                    SupplierId: command.SupplierId
                )
            );

        public static ItemAddedEvent ToEvent(this AddItemCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ItemAddedData(
                    ItemId: command.ItemId,
                    Quantity: command.Quantity,
                    Cost: command.Cost,
                    Note: command.Note,
                    DamagedQuantity: command.DamagedQuantity
                )
            );

        public static ShipmentAddedEvent ToEvent(this AddShipmentCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ShipmentAddedData(
                    ShippingId: Guid.NewGuid(),
                    ShippingType: command.ShippingType,
                    Cost: command.Cost,
                    Note: command.Note
                )
            );

        public static DamagedQuantityAdjustedEvent ToEvent(this AdjustDamagedQuantityCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new DamagedQuantityAdjustedData(
                    ItemId: command.ItemId,
                    DamagedQuantity: command.DamagedQuantity
                )
            );

        public static DeliveryCancelledEvent ToEvent(this CancelDeliveryCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new DeliveryCancelledData(command.CancellationNote)
            );

        public static DeadlineChangedEvent ToEvent(this ChangeDeadlineCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new DeadlineChangedData(command.Deadline)
            );

        public static InvoiceClosedEvent ToEvent(this CloseInvoiceCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new InvoiceClosedData()
            );

        public static ShippingConfirmedEvent ToEvent(this ConfirmShippingCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ShippingConfirmedData()
            );

        public static InvoiceDeletedEvent ToEvent(this DeleteInvoiceCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new InvoiceDeletedData()
            );

        public static DeliveredEvent ToEvent(this DeliverCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new DeliveredData(command.DeliveryNote)
            );

        public static ItemRemovedEvent ToEvent(this RemoveItemCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ItemRemovedData(command.ItemId)
            );

        public static ShipmentRemovedEvent ToEvent(this RemoveShipmentCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ShipmentRemovedData(command.ShippingId)
            );

        public static ShippingConfirmedEvent ToEvent(this UnconfirmShippingCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ShippingConfirmedData()
            );

        public static ItemUpdatedEvent ToEvent(this UpdateItemCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ItemUpdatedData(
                    ItemId: command.ItemId,
                    Quantity: command.Quantity,
                    Cost: command.Cost,
                    Note: command.Note
                )
            );

        public static ShipmentUpdatedEvent ToEvent(this UpdateShipmentCommand command, int sequence)
            => new(
                aggregateId: command.Id,
                userId: command.UserId,
                sequence: sequence,
                data: new ShipmentUpdatedData(
                    ShippingId: command.ShippingId,
                    ShippingType: command.ShippingType,
                    Cost: command.Cost,
                    Note: command.Note
                )
            );
    }
}
