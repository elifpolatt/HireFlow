using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Contracts.Services;
using HireFlow.Application.Features.Authentication.Dtos;
using MediatR;

namespace HireFlow.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, AuthenticationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IRefreshTokenGenerator refreshTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _refreshTokenGenerator = refreshTokenGenerator;
    }

    public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
            var email = request.Email.Trim().ToLowerInvariant(); //metindeki harferi küçük harfe dönüştürür. tolower()'dan farkı pc dilinden etkilenmez. daha güvenli benim için.

        var user = await _userRepository.GetByEmailAsync(email, cancellationToken);

        if (user is null || !user.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var passwordValid = _passwordHasher.Verify(request.Password,user.PasswordHash);

        if (!passwordValid)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var accessToken = _jwtService.GenerateAccessToken(user);

        var accessTokenExpiresAt = _jwtService.GetAccessTokenExpiration();

        var refreshToken = _refreshTokenGenerator.Generate();

        return new AuthenticationResponse(accessToken, refreshToken, accessTokenExpiresAt);
    }
}