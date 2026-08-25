using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using HireFlow.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Job job, CancellationToken cancellationToken)
        {
            await _context.Jobs.AddAsync(job, cancellationToken);
        }

        public async Task<IReadOnlyList<Job>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Jobs.AsNoTracking().OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
        }

        public async Task<Job?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
