using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record ConfirmShippingCommand(
        Guid Id,
        string UserId
    ) : IRequest<Invoice>;
}
