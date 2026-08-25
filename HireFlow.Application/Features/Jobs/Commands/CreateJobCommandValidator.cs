using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Location).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Department).NotEmpty().MaximumLength(150);

            RuleFor(x => x.CreatedBy).NotEmpty();

            RuleFor(x => x.SalaryMin).GreaterThanOrEqualTo(0).When(x => x.SalaryMin.HasValue);

            RuleFor(x => x.SalaryMax).GreaterThanOrEqualTo(0).When(x => x.SalaryMax.HasValue);

            RuleFor(x => x).Must(x => !x.SalaryMin.HasValue ||
            !x.SalaryMax.HasValue || x.SalaryMin <= x.SalaryMax).WithMessage("Minimum salary cannot be greater than maximum salary.");
        }
    }
}
