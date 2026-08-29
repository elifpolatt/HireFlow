using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

        Task<User?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
        //özellikle refresh tokenda kullanılacak

        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

        Task AddAsync(User user, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
