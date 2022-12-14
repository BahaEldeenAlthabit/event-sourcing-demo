using Anis.Purchases.Enums;
using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record AddShipmentCommand(
        Guid Id,
        string UserId,
        ShippingType ShippingType,
        decimal Cost,
        string Note
    ) : IRequest<Invoice>;
}
