using Shop.Core.SharedKernel;
using System;

namespace Shop.Application.Customer.Responses;

public class CreatedCustomerResponse(Guid id) : IResponse
{
    public Guid Id { get; } = id;
}