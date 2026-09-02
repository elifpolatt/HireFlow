using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Commands
{
    public record UpdateCandidateProfileCommand(Guid UserId,
        string? PhoneNumber,
        DateTime? BirthDate,
    string? LinkedinUrl,
    string? GithubUrl,
    int ExperienceYears,
    string? Summary) : IRequest;
}
