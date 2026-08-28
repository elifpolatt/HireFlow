using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Features.Jobs.Dtos;
using HireFlow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobs
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, IReadOnlyList<JobDto>>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobsQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IReadOnlyList<JobDto>> Handle(
            GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync(cancellationToken);

            return jobs.Select(job => new JobDto(
                job.Id,
                job.Title,
                job.Description,
                job.Department,
                job.SalaryMin,
                job.SalaryMax,
                job.CreatedBy,
                job.Status.ToString(),
                job.CreatedAt)).ToList();
        }
    }
}
