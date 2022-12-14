using Anis.Purchases.Models;
using System;

namespace Anis.Purchases.Data.Entities
{
    public class UniqueReference
    {
        private UniqueReference() { }
        public UniqueReference(Invoice invoice)
        {
            Id = invoice.Id;
            Reference = invoice.Reference;
            CustomerId = invoice.CustomerId;
        }

        public Guid Id { get; private set; }
        public string Reference { get; private set; }
        public string CustomerId { get; private set; }
    }
}
