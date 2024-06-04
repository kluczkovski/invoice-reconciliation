using Ardalis.GuardClauses;
using EK.InvoiceReconciliation.SharedKernel;
using EK.InvoiceReconciliation.SharedKernel.Interfaces;

namespace EK.InvoiceReconciliation.Core.Entities.Invoice;

public class Invoice : EntityBase, IAggregateRoot
{
  public Invoice()
  {
  }
  public Invoice(
    string invoiceNumber,
    string poNumber,
    DateTime invoiceDate,
    decimal total,
    decimal carriageTotal)
  {
    this.InvoiceNumber = invoiceNumber;
    this.PONumber = poNumber;
    this.InvoiceDate = invoiceDate;
    this.Total = total;
    this.CarriageTotal = carriageTotal;
  }

  public string InvoiceNumber { get; private set; }

  public string PONumber { get; private set; }

  public DateTime InvoiceDate { get; private set; }

  public decimal Total { get; private set; }

  public decimal CarriageTotal { get; set; }

  private List<InvoiceLine> _invoiceLines = new List<InvoiceLine>();
  public IEnumerable<InvoiceLine> InvoiceLines => _invoiceLines.AsReadOnly();

  public void AddInvoiceLine(InvoiceLine newInvoiceLine)
  {
    Guard.Against.Null(newInvoiceLine, nameof(newInvoiceLine));
    this._invoiceLines.Add(newInvoiceLine);
  }
}

