using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record DeleteInvoiceCommand(
        Guid Id,
        string UserId
    ) : IRequest;
}
