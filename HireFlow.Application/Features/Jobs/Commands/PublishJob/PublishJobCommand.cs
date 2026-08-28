using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.PublishJob
{
    public record PublishJobCommand(Guid JobId) : IRequest;
}
