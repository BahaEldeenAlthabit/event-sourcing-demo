using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record ChangeSupplierCommand(
        Guid Id,
        string UserId,
        string SupplierId
    ) : IRequest<Invoice>;
}
