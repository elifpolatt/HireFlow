using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Commands
{
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
