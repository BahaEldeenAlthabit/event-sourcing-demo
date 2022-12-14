using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record UpdateInvoiceInfoCommand(
        Guid Id,
        string UserId,
        string Statement,
        string PaymentNote
    ) : IRequest<Invoice>;
}
