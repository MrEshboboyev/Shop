using Ardalis.Result;
using MediatR;
using Shop.Query.QueriesModel;
using System.Collections.Generic;

namespace Shop.Query.Application.Customer.Queries;

public class GetAllCustomerQuery : IRequest<Result<IEnumerable<CustomerQueryModel>>>;