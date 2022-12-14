using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record UpdateItemCommand(
        Guid Id,
        string UserId,
        string ItemId,
        int Quantity,
        decimal Cost,
        string Note
    ) : IRequest<Invoice>;
}
