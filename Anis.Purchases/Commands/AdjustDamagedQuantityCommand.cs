using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record AdjustDamagedQuantityCommand(
        Guid Id,
        string UserId,
        string ItemId,
        int DamagedQuantity
    ) : IRequest<Invoice>;
}
