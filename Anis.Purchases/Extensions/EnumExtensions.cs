using Anis.Purchases.InvoicesProto.V1;
using System;

namespace Anis.Purchases.Extensions
{
    public static class EnumExtensions
    {
        public static InvoiceState ToProtoEnum(this Enums.InvoiceState state)
            => state switch
            {
                Enums.InvoiceState.Closed => InvoiceState.Closed,
                Enums.InvoiceState.Pending => InvoiceState.Pending,
                Enums.InvoiceState.SupplierAssinged => InvoiceState.SupplierAssigned,
                Enums.InvoiceState.ShippingConfirmed => InvoiceState.ShippingConfirmed,
                Enums.InvoiceState.Delivered => InvoiceState.Delivered,
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };

        public static Enums.InvoiceState ToDomainEnum(this InvoiceState state)
            => state switch
            {
                InvoiceState.Closed => Enums.InvoiceState.Closed,
                InvoiceState.Pending => Enums.InvoiceState.Pending,
                InvoiceState.SupplierAssigned => Enums.InvoiceState.SupplierAssinged,
                InvoiceState.ShippingConfirmed => Enums.InvoiceState.ShippingConfirmed,
                InvoiceState.Delivered => Enums.InvoiceState.Delivered,
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };

        public static ShippingType ToProtoEnum(this Enums.ShippingType state)
            => state switch
            {
                Enums.ShippingType.Sea => ShippingType.Sea,
                Enums.ShippingType.Domestic => ShippingType.Domestic,
                Enums.ShippingType.Air => ShippingType.Air,
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };

        public static Enums.ShippingType ToDomainEnum(this ShippingType state)
            => state switch
            {
                ShippingType.Sea => Enums.ShippingType.Sea,
                ShippingType.Domestic => Enums.ShippingType.Domestic,
                ShippingType.Air => Enums.ShippingType.Air,
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };
    }
}
