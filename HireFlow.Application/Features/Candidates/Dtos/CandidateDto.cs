using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Dtos
{
    public record CandidateDto(Guid Id,
        Guid UserId,
        string FirstName,
        string LastName,
        string Email,
        string? PhoneNumber,
        DateTime? BirthDate,
        string? CvUrl,
        string? LinkedinUrl,
        string? GithubUrl,
        int ExperienceYears,
        string? Summary);
    
}
