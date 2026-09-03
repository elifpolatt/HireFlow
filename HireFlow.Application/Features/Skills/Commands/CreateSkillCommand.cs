using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Commands
{
    public record CreateSkillCommand(Guid CandidateId, string Name) : IRequest<Guid>;
    
}
