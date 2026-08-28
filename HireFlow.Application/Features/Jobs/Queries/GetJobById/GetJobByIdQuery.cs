using HireFlow.Application.Features.Jobs.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobById
{
    public record GetJobByIdQuery(Guid id) : IRequest<JobDto>;
}
