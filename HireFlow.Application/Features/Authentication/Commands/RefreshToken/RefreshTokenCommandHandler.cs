using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Contracts.Services;
using HireFlow.Application.Features.Authentication.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResponse>
    {
        private readonly IRefreshTokenService _refreshTokenService;

        private readonly IUserRepository _userRepository;

        private readonly IJwtService _jwtService;

        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public RefreshTokenCommandHandler(IRefreshTokenService refreshTokenService,
            IUserRepository userRepository,
            IJwtService jwtService,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _refreshTokenService = refreshTokenService;
            _userRepository = userRepository;
            _jwtService = jwtService;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<AuthenticationResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userId = await _refreshTokenService.GetUserIdAsync(request.RefreshToken, cancellationToken);

            if (userId is null)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }

            var user = await _userRepository.GetByIdAsync(userId.Value, cancellationToken);

            if (user is null || !user.IsActive)
            {
                throw new UnauthorizedAccessException("User is not active.");
            }

            await _refreshTokenService.RemoveAsync(request.RefreshToken, cancellationToken);

            var accessToken = _jwtService.GenerateAccessToken(user);

            var accessTokenExpiresAt = _jwtService.GetAccessTokenExpiration();

            var newRefreshToken = _refreshTokenGenerator.Generate();

            var refreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);

            await _refreshTokenService.StoreAsync(newRefreshToken, user.Id, refreshTokenExpiresAt, cancellationToken);

            return new AuthenticationResponse(accessToken, newRefreshToken, accessTokenExpiresAt);
        }
    }
}
