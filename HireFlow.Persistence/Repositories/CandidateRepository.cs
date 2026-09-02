using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using HireFlow.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            await _context.Candidates.AddAsync(candidate, cancellationToken);
        }

        public async Task<Candidate?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Candidates.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
