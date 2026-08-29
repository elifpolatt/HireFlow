using HireFlow.Application.Contracts.Services;
using StackExchange.Redis;

namespace HireFlow.Infrastructure.Authentication
{
    public class RedisRefreshTokenService : IRefreshTokenService
    {
        private readonly StackExchange.Redis.IDatabase _database;
        public RedisRefreshTokenService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<Guid?> GetUserIdAsync(string refreshToken, CancellationToken cancellationToken)
        {
            var key = $"refresh-token:{refreshToken}";

            var value = await _database.StringGetAsync(key);

            if (!value.HasValue)
            {
                return null;
            }

            return Guid.Parse(value!.ToString());
        }

        public async Task RemoveAsync(string refreshToken, CancellationToken cancellationToken)
        {
            var key = $"refresh-token:{refreshToken}";

            await _database.KeyDeleteAsync(key);
        }

        public async Task StoreAsync(string refreshToken, Guid userId, DateTime expiresAt, CancellationToken cancellationToken)
        {
            var key = $"refresh-token:{refreshToken}";

            var expiry = expiresAt - DateTime.UtcNow;

            await _database.StringSetAsync(key, userId.ToString(), expiry);
        }
    }
}
