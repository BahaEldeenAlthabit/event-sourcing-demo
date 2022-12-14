using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record CreateInvoiceCommand(
        string UserId,
        string CustomerId,
        string Reference,
        DateTime Deadline,
        string Statement,
        string PaymentNote
    ) : IRequest<Invoice>;
}
