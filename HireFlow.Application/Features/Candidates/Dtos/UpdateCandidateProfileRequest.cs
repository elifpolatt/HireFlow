using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Dtos
{
    public record UpdateCandidateProfileRequest(string? PhoneNumber,
        DateTime? BirthDate,
        string? LinkedinUrl,
        string? GithubUrl,
        int ExperienceYears,
        string? Summary);
}
