using HireFlow.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Commands
{
    public class UpdateCandidateProfileCommandHandler : IRequestHandler<UpdateCandidateProfileCommand>
    {
        private readonly ICandidateRepository _candidateRepository;

        public UpdateCandidateProfileCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task Handle(UpdateCandidateProfileCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByUserIdAsync(request.UserId, cancellationToken);

            if (candidate == null)
            {
                throw new KeyNotFoundException("Candidate profile not found");
            }

            candidate.UpdateProfile(
                request.PhoneNumber,
                request.BirthDate,
                request.LinkedinUrl,
                request.GithubUrl,
                request.ExperienceYears,
                request.Summary);

            await _candidateRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
