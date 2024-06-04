using Ardalis.Specification;

namespace EK.InvoiceReconciliation.SharedKernel.Interfaces;

public interface IReadyRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    
}
