using HireFlow.Application.Features.Candidates.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Candidates.Queries.GetCandidates
{
    public record GetCandidateProfileQuery(Guid UserId) : IRequest<CandidateDto>;
}
