using Ardalis.Result;
using MediatR;
using Shop.Query.QueriesModel;
using System;

namespace Shop.Query.Application.Customer.Queries;

public class GetCustomerByIdQuery(Guid id) : IRequest<Result<CustomerQueryModel>>
{
    public Guid Id { get; } = id;
}