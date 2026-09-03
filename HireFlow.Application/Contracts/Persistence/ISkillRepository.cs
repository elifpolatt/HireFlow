using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill,  CancellationToken cancellationToken);

        Task<Skill?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Skill>> GetByCandidateIdAsync(Guid candidateId, CancellationToken cancellationToken);

        void Delete(Skill skill);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
