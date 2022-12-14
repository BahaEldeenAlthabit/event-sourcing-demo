using Anis.Purchases.Commands;
using Anis.Purchases.Data;
using Anis.Purchases.Models;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anis.Purchases.Handlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
    {
        private readonly ApplicationDbContext _context;

        public CreateInvoiceHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            if (await _context.UniqueReferences.AnyAsync(
                e => e.Reference == command.Reference && e.CustomerId == command.CustomerId,
                cancellationToken: cancellationToken
            ))
            {
                throw new RpcException(new Status(StatusCode.AlreadyExists, ""));
            }

            var invoice = Invoice.Create(command);

            await _context.CommitNewEventsAsync(invoice);

            return invoice;
        }
    }
}
