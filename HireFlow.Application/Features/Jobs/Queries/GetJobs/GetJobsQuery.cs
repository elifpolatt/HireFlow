using HireFlow.Application.Features.Jobs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobs
{
    public record GetJobsQuery(int PageNumber = 1, 
        int PageSize = 10,
        string? Search = null,
        string? Location = null,
        string? Department = null
        ) : IRequest<IReadOnlyList<JobDto>>;
}
