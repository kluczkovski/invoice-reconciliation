
using System.Reflection;
using EK.InvoiceReconciliation.Core.Entities.Invoice;
using Microsoft.EntityFrameworkCore;

namespace EK.InvoiceReconciliation.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Invoice> Invoices => Set<Invoice>();
  public DbSet<InvoiceLine> InvoicesLines => Set<InvoiceLine>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // get all classes that have implmented the IEntityTypeConfiguration interface
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    base.OnModelCreating(modelBuilder);
  }
}

