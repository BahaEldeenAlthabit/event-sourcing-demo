using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record RemoveShipmentCommand(
        Guid Id,
        string UserId,
        Guid ShippingId
    ) : IRequest<Invoice>;
}
