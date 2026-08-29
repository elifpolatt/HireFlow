using HireFlow.Application.Features.Authentication.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<AuthenticationResponse>;
}
