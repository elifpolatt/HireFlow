using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using HireFlow.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HireFlow.Persistence.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Candidates.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
