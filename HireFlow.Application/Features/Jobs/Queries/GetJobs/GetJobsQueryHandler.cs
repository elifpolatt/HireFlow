using HireFlow.Application.Common.Models;
using HireFlow.Application.Contracts.Persistence;
using HireFlow.Application.Features.Jobs.Dtos;
using Microsoft.EntityFrameworkCore;
using HireFlow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Jobs.Queries.GetJobs
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, PaginatedResult<JobDto>>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobsQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<PaginatedResult<JobDto>> Handle(
            GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _jobRepository.Query()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();

                query = query.Where(x => x.Title.Contains(search) || 
                x.Description.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(request.Location))
            {
                query = query.Where(x => x.Location == request.Location);
            }

            if (!string.IsNullOrWhiteSpace(request.Department))
            {
                query = query.Where(x => x.Department == request.Department);
            }

            query = request.SortBy?.ToLowerInvariant() switch
            {
                "title" => request.SortDirection == "asc"
                    ? query.OrderBy(x => x.Title)
                    : query.OrderByDescending(x => x.Title),

                "salarymin" => request.SortDirection == "asc"
                    ? query.OrderBy(x => x.SalaryMin)
                    : query.OrderByDescending(x => x.SalaryMin),

                "salarymax" => request.SortDirection == "asc"
                    ? query.OrderBy(x => x.SalaryMax)
                    : query.OrderByDescending(x => x.SalaryMax),

                "createdat" => request.SortDirection == "asc"
                    ? query.OrderBy(x => x.CreatedAt)
                    : query.OrderByDescending(x => x.CreatedAt),

                _ => query.OrderByDescending(x => x.CreatedAt)
            };

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query.Skip((request.PageNumber -1) * request.PageSize).Take(request.PageSize)
                .Select(job => new JobDto(
                job.Id,
                job.Title,
                job.Description,
                job.Department,
                job.SalaryMin,
                job.SalaryMax,
                job.CreatedBy,
                job.Status.ToString(),
                job.CreatedAt)).ToListAsync(cancellationToken);

            return new PaginatedResult<JobDto> { Items = items ,
            PageNumber = request.PageNumber,
            
            PageSize = request.PageSize,
            TotalCount = totalCount};
        }
    }
}
