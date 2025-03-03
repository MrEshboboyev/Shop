using Shop.Query.Abstractions;
using Shop.Query.QueriesModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Query.Data.Repositories.Abstractions;

public interface ICustomerReadOnlyRepository : IReadOnlyRepository<CustomerQueryModel, Guid>
{
    Task<IEnumerable<CustomerQueryModel>> GetAllAsync();
}