using HireFlow.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.id, cancellationToken);

            if(job is null)
            {
                throw new KeyNotFoundException($"Job '{request.id}' was not found.");
            }

            job.Update(request.Title, request.Desciption, request.Location, request.Department, request.SalaryMin, request.SalaryMax);

            await _jobRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
