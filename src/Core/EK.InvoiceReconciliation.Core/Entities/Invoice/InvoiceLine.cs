using Ardalis.GuardClauses;
using EK.InvoiceReconciliation.SharedKernel;

namespace EK.InvoiceReconciliation.Core.Entities.Invoice;

public class InvoiceLine : EntityBase
{
  public InvoiceLine(
    string stockCode,
    string description,
    decimal price,
    decimal quantity)
  {
    this.StockCode = Guard.Against.NullOrEmpty(stockCode);
    this.Description = Guard.Against.NullOrEmpty(description);
    this.Price = Guard.Against.Negative(price);
    this.Quantity = Guard.Against.Negative(quantity);
  }

  public Invoice Invoice { get; set; }
  public int InvoiceId { get; set; }

  public string StockCode { get; private set; }

  public string Description { get; private set ; }

  public decimal Price { get; private set; }

  public decimal Quantity { get; private set; }

}

