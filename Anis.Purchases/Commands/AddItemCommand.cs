using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record AddItemCommand(
        Guid Id,
        string UserId,
        string ItemId,
        int Quantity,
        decimal Cost,
        string Note,
        int DamagedQuantity
    ) : IRequest<Invoice>;
}
