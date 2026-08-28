using HireFlow.Application.Features.Jobs.Commands.CreateJob;
using HireFlow.Application.Features.Jobs.Queries.GetJobById;
using HireFlow.Application.Features.Jobs.Queries.GetJobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ISender _sender;

        public JobsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobCommand command, CancellationToken cancellationToken)
        {
            var jobId = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = jobId }, new { id = jobId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetJobsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetJobByIdQuery(id), cancellationToken);
            return Ok(result);
        }
    }
}
