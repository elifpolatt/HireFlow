using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Logout
{
    public record LogoutCommand(string RefreshToken) : IRequest<Unit>;
}
