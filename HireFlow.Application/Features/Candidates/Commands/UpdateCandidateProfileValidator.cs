using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Commands
{
    public class UpdateCandidateProfileValidator : AbstractValidator<UpdateCandidateProfileCommand>
    {
        public UpdateCandidateProfileValidator()
        {
            RuleFor(x => x.ExperienceYears).InclusiveBetween(0, 50).WithMessage("Experience years must be between 0 and 50");

            RuleFor(x => x.PhoneNumber).MaximumLength(30).When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));
            RuleFor(x => x.LinkedinUrl).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.LinkedinUrl));
            RuleFor(x => x.GithubUrl).MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.GithubUrl));
            RuleFor(x => x.Summary).MaximumLength(2000).When(x => !string.IsNullOrWhiteSpace(x.Summary));
            RuleFor(x => x.BirthDate).LessThan(DateTime.UtcNow).When(x => x.BirthDate.HasValue);
        }
    }
}
