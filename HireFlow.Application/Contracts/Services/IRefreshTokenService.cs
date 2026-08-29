using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HireFlow.Application.Contracts.Services
{
    public interface IRefreshTokenService
    {
        Task StoreAsync(string refreshToken, Guid userId, DateTime expiresAt, CancellationToken cancellationToken);

        Task<Guid?> GetUserIdAsync(string refreshToken, CancellationToken cancellationToken);

        Task RemoveAsync(string refreshToken, CancellationToken cancellationToken);
    }
}
