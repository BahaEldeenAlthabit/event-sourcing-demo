using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record CloseInvoiceCommand(
        Guid Id,
        string UserId
    ) : IRequest<Invoice>;
}
