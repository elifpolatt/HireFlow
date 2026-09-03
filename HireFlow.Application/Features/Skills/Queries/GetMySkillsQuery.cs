using HireFlow.Application.Common.Interfaces;
using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Features.Skills.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Queries
{
    public record GetMySkillsQuery : IRequest<List<SkillDto>>;

    public class GetMySkillsQueryHandler : IRequestHandler<GetMySkillsQuery, List<SkillDto>>
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly ICandidateRepository _candidateRepository;

        private readonly ISkillRepository _skillRepository;

        public GetMySkillsQueryHandler(ICurrentUserService currentUserService,
            ICandidateRepository candidateRepository,
            ISkillRepository skillRepository)
        {
            _currentUserService = currentUserService;
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDto>> Handle(GetMySkillsQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByUserIdAsync(_currentUserService.UserId, cancellationToken);

            if (candidate == null)
            {
                throw new UnauthorizedAccessException("Candidate profile not found");

            }
            var skills = await _skillRepository.GetByCandidateIdAsync(candidate.Id, cancellationToken);

            return skills.Select(x => new SkillDto
            (
                x.Id,
                x.Name)).ToList();
        }
    }
}

