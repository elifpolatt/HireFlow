using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Dtos
{
    public sealed record JobDto(
        Guid Id,
        string Title,
        string Description,
        string Department,
        decimal? SalaryMin,
        decimal? SalaryMax,
        Guid CreatedBy,
        string Status,
        DateTime CreatedAt);
}
