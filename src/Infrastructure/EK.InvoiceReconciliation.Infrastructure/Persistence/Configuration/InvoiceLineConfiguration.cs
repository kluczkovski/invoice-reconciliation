using EK.InvoiceReconciliation.Core.Entities.Invoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EK.InvoiceReconciliation.Infrastrucutre.Persistence.Configuration;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{

  public void Configure(EntityTypeBuilder<InvoiceLine> builder)
  {
    builder.HasKey(i => i.Id);

    builder.Property(il => il.StockCode)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(il => il.Description)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(il => il.Quantity)
      .HasPrecision(2);

    builder.Property(il => il.Price)
      .HasPrecision(4);
  }
}

