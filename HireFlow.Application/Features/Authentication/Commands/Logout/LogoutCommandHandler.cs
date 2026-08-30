using HireFlow.Application.Contracts.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Logout
{
    public class LogoutCommandHandler
    : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public LogoutCommandHandler(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public async Task<Unit> Handle( LogoutCommand request, CancellationToken cancellationToken)
        {
            await _refreshTokenService.RemoveAsync( request.RefreshToken, cancellationToken);

            return Unit.Value;
        }
    }
}
