using HireFlow.Application.Contracts.Services;
using HireFlow.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace HireFlow.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration.GetConnectionString("Redis") ?? throw new InvalidDataException("Redis connection string is missing.");

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));

            services.AddScoped<IRefreshTokenService, RedisRefreshTokenService>();

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();

            return services;
        }
    }
}
