using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record RemoveItemCommand(
        Guid Id,
        string UserId,
        string ItemId
    ) : IRequest<Invoice>;
}
