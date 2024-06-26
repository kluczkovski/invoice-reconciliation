﻿using Ardalis.Specification;

namespace EK.InvoiceReconciliation.SharedKernel.Interfaces;

public interface IRepository<T>: IRepositoryBase<T> where T : class, IAggregateRoot
{
}

