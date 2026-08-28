using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobs
{
    public class GetJobsQueryValidator : AbstractValidator<GetJobsQuery>
    {
        public GetJobsQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);

            RuleFor(x => x.SortDirection).Must(x => string.IsNullOrWhiteSpace(x) ||
            x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
            x.Equals("desc", StringComparison.OrdinalIgnoreCase)).WithMessage("SortDirection must be 'asc' or 'desc'");
        }
    }
}
