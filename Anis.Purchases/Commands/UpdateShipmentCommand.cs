using Anis.Purchases.Enums;
using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record UpdateShipmentCommand(
        Guid Id,
        string UserId,
        Guid ShippingId,
        ShippingType ShippingType,
        decimal Cost,
        string Note
    ) : IRequest<Invoice>;
}
