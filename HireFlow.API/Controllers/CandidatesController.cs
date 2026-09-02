using HireFlow.Application.Features.Candidates.Queries.GetCandidates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HireFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Candidate")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile(CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            if(!Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var result = await _mediator.Send(new GetCandidateProfileQuery(userId), cancellationToken);

            return Ok(result);
        }
    }
}
