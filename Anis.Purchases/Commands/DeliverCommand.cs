using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record DeliverCommand(
        Guid Id,
        string UserId,
        string DeliveryNote
    ) : IRequest<Invoice>;
}
