using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Contracts.Services;
using HireFlow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
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
                request.UserRole);

            await _userRepository.AddAsync(user, cancellationToken);

            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
