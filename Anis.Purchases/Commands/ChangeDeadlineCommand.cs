using Anis.Purchases.Models;
using MediatR;
using System;

namespace Anis.Purchases.Commands
{
    public record ChangeDeadlineCommand(
        Guid Id,
        string UserId,
        DateTime Deadline
    ) : IRequest<Invoice>;
}
