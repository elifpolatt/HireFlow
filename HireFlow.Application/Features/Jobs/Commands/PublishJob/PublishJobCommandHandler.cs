using HireFlow.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.PublishJob
{
    public class PublishJobCommandHandler : IRequestHandler<PublishJobCommand>
    {
        private readonly IJobRepository _jobRepository;
        public PublishJobCommandHandler(IJobRepository jobRepository )
        {
            _jobRepository = jobRepository;
        }

        public async Task Handle(PublishJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.JobId, cancellationToken);


            if (job == null) {
                throw new KeyNotFoundException($"Job was not found");    
            }
            job.Publish();

            await _jobRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
