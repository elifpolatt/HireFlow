using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface IJobRepository
    {
        IQueryable<Job> Query();

        Task AddAsync(Job job, CancellationToken cancellationToken);

        Task<Job?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);

        void Delete(Job job);
    }
}
