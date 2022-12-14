using Anis.Purchases.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anis.Purchases.Data.Configurations
{
    public class UniqueReferenceConfiguration : IEntityTypeConfiguration<UniqueReference>
    {
        public void Configure(EntityTypeBuilder<UniqueReference> builder)
        {
            builder.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Reference)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasIndex(e => new { e.CustomerId, e.Reference }).IsUnique();
        }
    }
}
