using HireFlow.Domain.Entities;

namespace HireFlow.Application.Contracts.Persistence
{
    public interface ICandidateRepository
    {
        Task<Candidate?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
