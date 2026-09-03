using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Skills.Commands
{
    public record CreateSkillCommand(string Name) : IRequest<Guid>;
    
}
