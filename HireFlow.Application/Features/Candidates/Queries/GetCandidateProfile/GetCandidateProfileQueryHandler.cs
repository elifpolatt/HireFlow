using FluentValidation.Validators;
using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Features.Candidates.Dtos;
using HireFlow.Application.Features.Candidates.Queries.GetCandidates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Queries.GetCandidateProfile
{
    public class GetCandidateProfileQueryHandler : IRequestHandler<GetCandidateProfileQuery, CandidateDto>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidateProfileQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateDto> Handle(GetCandidateProfileQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByUserIdAsync(request.UserId, cancellationToken);

            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate profile not found");
            }

            return new CandidateDto(candidate.Id,
                candidate.UserId,
                candidate.User.FirstName,
                candidate.User.LastName,
                candidate.User.Email,
                candidate.PhoneNumber,
                candidate.BirthDate,
                candidate.CvUrl,
                candidate.LinkedinUrl,
                candidate.GithubUrl,
                candidate.ExperienceYears,
                candidate.Summary)
;        }
    }
}
