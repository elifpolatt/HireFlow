using HireFlow.Application.Features.Candidates.Commands;
using HireFlow.Application.Features.Candidates.Dtos;
using HireFlow.Application.Features.Candidates.Queries.GetCandidates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
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
            var userIdClaim = User.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var result = await _mediator.Send(new GetCandidateProfileQuery(userId), cancellationToken);

            return Ok(result);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(UpdateCandidateProfileRequest request, CancellationToken cancellationToken)
        {
            var userIdClaim = User.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var command = new UpdateCandidateProfileCommand(userId,
                request.PhoneNumber,
                request.BirthDate,
                request.LinkedinUrl,
                request.GithubUrl,
                request.ExperienceYears,
                request.Summary);

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
