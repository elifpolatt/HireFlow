using HireFlow.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password, UserRole UserRole) : IRequest<Guid>;
}
