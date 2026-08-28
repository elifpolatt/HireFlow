using HireFlow.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
    {
        private readonly IJobRepository _jobRepository;
        public DeleteJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.Id, cancellationToken);

            if (job is null)
            {
                throw new KeyNotFoundException($"Job '{request.Id}' was not found.");
            }

            _jobRepository.Delete(job);

            await _jobRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
