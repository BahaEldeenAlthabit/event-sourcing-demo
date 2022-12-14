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
    public class AddItemHandler : IRequestHandler<AddItemCommand, Invoice>
    {
        private readonly ApplicationDbContext _context;

        public AddItemHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            var events = await _context.EventStore.Where(e => e.AggregateId == command.Id)
                                                  .OrderBy(e => e.Sequence)
                                                  .ToListAsync(cancellationToken: cancellationToken);

            if (events.Count == 0)
                throw new RpcException(new Status(StatusCode.NotFound, "MESSAGE HERE"));

            var invoice = Invoice.LoadFromHistory(events);

            invoice.AddItem(command);

            await _context.CommitNewEventsAsync(invoice);

            return invoice;
        }
    }
}
