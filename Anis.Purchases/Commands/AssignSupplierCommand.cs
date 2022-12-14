using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record AssignSupplierCommand(
        Guid Id,
        string UserId,
        string SupplierId
    ) : IRequest<Invoice>;
}
