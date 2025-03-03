using Ardalis.Result;
using MediatR;
using System;

namespace Shop.Application.Customer.Commands;

public class DeleteCustomerCommand(Guid id) : IRequest<Result>
{
    public Guid Id { get; } = id;
}