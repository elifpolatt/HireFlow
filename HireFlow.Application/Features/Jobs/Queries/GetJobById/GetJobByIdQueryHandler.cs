using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Features.Jobs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobById
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, JobDto>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobByIdQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<JobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.id, cancellationToken);

            if (job == null)
            {
                throw new KeyNotFoundException($"Job with id '{request.id}' was not found.");
            }

            return new JobDto(
                job.Id,
                job.Title,
                job.Description,
                job.Department,
                job.SalaryMin,
                job.SalaryMax,
                job.CreatedBy,
                job.Status.ToString(),
                job.CreatedAt);
        }
    }
}
