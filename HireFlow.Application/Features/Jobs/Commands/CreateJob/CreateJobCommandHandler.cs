using HireFlow.Application.Contracts.Persistence;
using HireFlow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job(request.Title,
                request.Description,
                request.Department,
                request.Location,
                request.CreatedBy,
                request.SalaryMin,
                request.SalaryMax);

            await _jobRepository.AddAsync(job, cancellationToken);

            await _jobRepository.SaveChangesAsync(cancellationToken);

            return job.Id;
        }
    }
}
