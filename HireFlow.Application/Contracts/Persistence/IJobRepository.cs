using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface IJobRepository
    {
        Task AddAsync(Job job, CancellationToken cancellationToken);

        Task<Job?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IReadOnlyList<Job>> GetAllAsync(CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
