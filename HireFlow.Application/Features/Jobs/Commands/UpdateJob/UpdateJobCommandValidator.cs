using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);

            RuleFor(x => x.Desciption).NotEmpty();

            RuleFor(x => x.Location).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Department).NotEmpty().MaximumLength(150);

            RuleFor(x => x.SalaryMin).GreaterThanOrEqualTo(0).When(x => x.SalaryMin.HasValue);

            RuleFor(x => x.SalaryMax).GreaterThanOrEqualTo(0).When(x => x.SalaryMax.HasValue);
            
            RuleFor(x => x).Must(x =>
                !x.SalaryMin.HasValue ||
                !x.SalaryMax.HasValue ||
                x.SalaryMin <= x.SalaryMax).WithMessage(
                "Minimum salary cannot be greater than maximum salary.");
        }
    }
}
