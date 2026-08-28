using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands.UpdateJob
{
    public record UpdateJobCommand(
        Guid id,
        string Title,
        string Desciption,
        string Location,
        string Department,
        decimal? SalaryMin,
        decimal? SalaryMax) : IRequest;
}
