using HireFlow.Application.Features.Jobs.Commands.CreateJob;
using HireFlow.Application.Features.Jobs.Commands.DeleteJob;
using HireFlow.Application.Features.Jobs.Commands.PublishJob;
using HireFlow.Application.Features.Jobs.Commands.UpdateJob;
using HireFlow.Application.Features.Jobs.Queries.GetJobById;
using HireFlow.Application.Features.Jobs.Queries.GetJobs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireFlow.API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAll([FromBody] GetJobsQuery query,CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetJobByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]UpdateJobRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateJobCommand(id, request.Title, request.Description, request.Location, request.Department, request.SalaryMin, request.SalaryMax);

            await _sender.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _sender.Send(new DeleteJobCommand(id), cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}/publish")]
        public async Task<IActionResult> Publish(Guid id, CancellationToken cancellationToken)
        {
            await _sender.Send(new PublishJobCommand(id), cancellationToken);

            return NoContent();
        }

        public record UpdateJobRequest(string Title, string Description, string Location, string Department, decimal? SalaryMin, decimal? SalaryMax);
    }
}
