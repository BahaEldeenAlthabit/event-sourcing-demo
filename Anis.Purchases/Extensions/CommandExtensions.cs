using Anis.Purchases.Commands;
using Anis.Purchases.InvoicesProto.V1;
using System;

namespace Anis.Purchases.Extensions
{
    public static class CommandExtensions
    {
        public static CreateInvoiceCommand ToCommand(this CreateRequest request)
            => new(
                UserId: request.UserId,
                CustomerId: request.CustomerId,
                Reference: request.Reference,
                Deadline: request.Deadline.ToDateTime(),
                Statement: request.Statement,
                PaymentNote: request.PaymentNote
            );

        public static UpdateInvoiceInfoCommand ToCommand(this UpdateInfoRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                Statement: request.Statement,
                PaymentNote: request.PaymentNote
            );

        public static AssignSupplierCommand ToAssignCommand(this SupplierRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                SupplierId: request.SupplierId
            );

        public static ChangeSupplierCommand ToChangeCommand(this SupplierRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                SupplierId: request.SupplierId
            );

        public static ChangeDeadlineCommand ToCommand(this ChangeDeadlineRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                Deadline: request.Deadline.ToDateTime()
            );

        public static AddItemCommand ToCommand(this AddItemRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ItemId: request.ItemId,
                Quantity: request.Quantity,
                Cost: (decimal)request.Cost,
                Note: request.Note,
                DamagedQuantity: request.DamagedQuantity
            );

        public static AddShipmentCommand ToCommand(this AddShipmentRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ShippingType: request.ShippingType.ToDomainEnum(),
                Cost: (decimal)request.Cost,
                Note: request.Note
            );

        public static AdjustDamagedQuantityCommand ToCommand(this AdjustDamagedQuantityRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ItemId: request.ItemId,
                DamagedQuantity: request.DamagedQuantity
            );

        public static CancelDeliveryCommand ToCommand(this CancelDeliveryRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                CancellationNote: request.CancellationNote
            );

        public static CloseInvoiceCommand ToCommand(this CloseRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId
            );

        public static ConfirmShippingCommand ToCommand(this ConfirmShippingRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId
            );

        public static DeleteInvoiceCommand ToCommand(this DeleteRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId
            );

        public static DeliverCommand ToCommand(this DeliverRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                DeliveryNote: request.DeliveryNote
            );

        public static RemoveItemCommand ToCommand(this RemoveItemRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ItemId: request.ItemId
            );

        public static RemoveShipmentCommand ToCommand(this RemoveShipmentRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ShippingId: Guid.Parse(request.ShipmentId)
            );

        public static UnconfirmShippingCommand ToCommand(this UnconfirmShippingRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                Note: request.Note
            );

        public static UpdateItemCommand ToCommand(this UpdateItemRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ItemId: request.ItemId,
                Quantity: request.Quantity,
                Cost: (decimal)request.Cost,
                Note: request.Note
            );

        public static UpdateShipmentCommand ToCommand(this UpdateShipmentRequest request)
            => new(
                Id: Guid.Parse(request.Id),
                UserId: request.UserId,
                ShippingId: Guid.Parse(request.ShipmentId),
                ShippingType: request.ShippingType.ToDomainEnum(),
                Cost: (decimal)request.Cost,
                Note: request.Note
            );
    }
}
