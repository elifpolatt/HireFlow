using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Commands
{
    public record CreateJobCommand(
        string Title,
        string Description,
        string Location,
        string Department,
        Guid CreatedBy,
        decimal? SalaryMin,
        decimal? SalaryMax) : IRequest<Guid> //bu command çalıştığında bana bir guid döndür. oluşturulan job'ın id'sini döndürecegiz
    {

    }
}
