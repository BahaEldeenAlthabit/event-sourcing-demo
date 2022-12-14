﻿using Anis.Purchases.Commands;
using Anis.Purchases.Data;
using Anis.Purchases.Models;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Anis.Purchases.Handlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteInvoiceHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand command, CancellationToken cancellationToken)
        {
            var events = await _context.EventStore.Where(e => e.AggregateId == command.Id)
                                                  .OrderBy(e => e.Sequence)
                                                  .ToListAsync(cancellationToken: cancellationToken);

            if (events.Count == 0)
                throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            var invoice = Invoice.LoadFromHistory(events);

            invoice.DeleteInvoice(command);

            await _context.CommitNewEventsAsync(invoice);

            return Unit.Value;
        }
    }
}
