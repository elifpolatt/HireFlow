using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using HireFlow.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Skill skill, CancellationToken cancellationToken)
        {
            await _context.Skills.AddAsync(skill, cancellationToken);
        }

        public void Delete(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public async Task<List<Skill>> GetByCandidateIdAsync(Guid candidateId, CancellationToken cancellationToken)
        {
            return await _context.Skills.AsNoTracking().Where(x => x.CandidateId == candidateId).OrderBy(x => x.Name).ToListAsync(cancellationToken);
        }

        public async Task<Skill?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
