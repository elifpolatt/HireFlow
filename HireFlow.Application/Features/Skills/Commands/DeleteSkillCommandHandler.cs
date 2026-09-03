using HireFlow.Application.Common.Interfaces;
using HireFlow.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Commands
{
    public record DeleteSkillCommand(Guid SkillId) : IRequest<Unit>;

    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, Unit>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillCommandHandler(ICurrentUserService currentUserService,
        ICandidateRepository candidateRepository,
        ISkillRepository skillRepository)
        {
            _currentUserService = currentUserService;
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByUserIdAsync(_currentUserService.UserId, cancellationToken);

            if (candidate is null)
            {
                throw new UnauthorizedAccessException("Candidate profile not found.");
            }

            var skill = await _skillRepository.GetByIdAsync(request.SkillId, cancellationToken);

            if (skill is null)
            {
                throw new KeyNotFoundException( "Skill not found.");
            }

            if (skill.CandidateId != candidate.Id)
            {
                throw new UnauthorizedAccessException("You cannot delete another candidate's skill.");
            }

            _skillRepository.Delete(skill);

            await _skillRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
