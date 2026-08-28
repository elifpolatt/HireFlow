using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.DeleteJob
{
    public record DeleteJobCommand(Guid Id) : IRequest;
}
