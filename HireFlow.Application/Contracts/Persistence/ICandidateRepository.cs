using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface ICandidateRepository
    {
        Task<Candidate?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        Task AddAsync(Candidate candidate, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
