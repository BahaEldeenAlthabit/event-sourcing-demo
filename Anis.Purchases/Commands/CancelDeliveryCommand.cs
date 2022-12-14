using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record CancelDeliveryCommand(
        Guid Id,
        string UserId,
        string CancellationNote
    ) : IRequest<Invoice>;
}
