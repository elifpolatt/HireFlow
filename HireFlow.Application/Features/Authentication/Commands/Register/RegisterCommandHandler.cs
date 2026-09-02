using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Contracts.Services;
using HireFlow.Application.Features.Authentication.Dtos;
using HireFlow.Domain.Entities;
using HireFlow.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenService _refreshTokenService;

        private readonly ICandidateRepository _candidateRepository;

        public RegisterCommandHandler(IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IRefreshTokenGenerator refreshTokenGenerator,
        IRefreshTokenService refreshTokenService,
        ICandidateRepository candidateRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenService = refreshTokenService;
            _candidateRepository = candidateRepository;
        }

        public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var exists = await _userRepository.ExistsByEmailAsync(
                    email,
                    cancellationToken);

            if (exists)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var passwordHash = _passwordHasher.Hash(request.Password);

            var user = new User(request.FirstName.Trim(), request.LastName.Trim(), email, passwordHash,
                UserRole.Candidate);

            await _userRepository.AddAsync(user, cancellationToken);

            var candidate = new Candidate(user.Id);

            await _candidateRepository.AddAsync(candidate, cancellationToken);

            await _userRepository.SaveChangesAsync(cancellationToken);

            var accessToken = _jwtService.GenerateAccessToken(user);

            var accessTokenExpiresAt = _jwtService.GetAccessTokenExpiration();

            var refreshToken = _refreshTokenGenerator.Generate();

            var refreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);

            await _refreshTokenService.StoreAsync(
                refreshToken,
                user.Id,
                refreshTokenExpiresAt,
                cancellationToken);

            return new AuthenticationResponse(
                accessToken,
                refreshToken,
                accessTokenExpiresAt);
        }
    }
}
