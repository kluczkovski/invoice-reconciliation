using EK.InvoiceReconciliation.Core.Entities.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EK.InvoiceReconciliation.Infrastrucutre.Persistence.Configuration;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
  
  public void Configure(EntityTypeBuilder<Invoice> builder)
  {
    builder.HasKey(i => i.Id);

    builder.Property(i => i.InvoiceNumber)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(i => i.PONumber)
      .IsRequired()
      .HasMaxLength(70);

    builder.Property(i => i.Total)
      .HasPrecision(2);

    builder.Property(i => i.CarriageTotal)
      .HasPrecision(2);

    builder.HasMany(i => i.InvoiceLines)
      .WithOne(il => il.Invoice)
      .OnDelete(DeleteBehavior.ClientCascade);
    
  }
}

