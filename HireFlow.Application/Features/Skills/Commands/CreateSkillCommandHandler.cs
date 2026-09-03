using HireFlow.Application.Common.Interfaces;
using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Commands
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Guid>
    {
        private readonly ICandidateRepository _candidateRepository;

        private readonly ISkillRepository _skillRepository;

        private readonly ICurrentUserService _currentUserService;
        public CreateSkillCommandHandler(ICandidateRepository candidateRepository,
            ISkillRepository skillRepository,
            ICurrentUserService currentUserService)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Guid> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var candidate = await _candidateRepository.GetByUserIdAsync(userId, cancellationToken);

            if (candidate == null)
            {
                throw new UnauthorizedAccessException("Candidate profile not found ");

            }

            var skill = new Skill(candidate.Id, request.Name.Trim());

            await _skillRepository.AddAsync(skill, cancellationToken);

            await _skillRepository.SaveChangesAsync(cancellationToken);

            return skill.Id;
        }
    }
}
