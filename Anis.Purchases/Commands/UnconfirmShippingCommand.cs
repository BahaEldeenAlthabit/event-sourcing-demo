using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record UnconfirmShippingCommand(
        Guid Id,
        string UserId,
        string Note
    ) : IRequest<Invoice>;
}
