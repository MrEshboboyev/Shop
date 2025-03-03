using Ardalis.Result;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Customer.Commands;

public class UpdateCustomerCommand : IRequest<Result>
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}