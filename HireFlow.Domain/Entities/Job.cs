using HireFlow.Domain.Common;
using HireFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Job : AuditableEntity
    {
        public string Title { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string Location { get; private set; } = null!;
        public string Department { get; private set; } = null!;
        public decimal? SalaryMin{ get; private set; }
        public decimal? SalaryMax{ get; private set; }
        public JobStatus Status{ get; private set; }
        public Guid CreatedBy { get; private set; }
        public User Creator { get; private set; } = null!;

        private Job() { }

        public Job(
            string title,
            string description,
            string location,
            string department,
            Guid createdBy,
            decimal? salaryMin = null,
            decimal? salaryMax = null)
        {
            Title = title;
            Description = description;
            Location = location;
            Department = department;
            CreatedBy = createdBy;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            Status = JobStatus.Draft;
        }
        public void Publish()
        {
            if(Status != JobStatus.Draft)
            {
                throw new InvalidOperationException("Only draft jobs can be publised.");
            }
            Status = JobStatus.Published;
        }

        public void Close()
        {
            if (Status != JobStatus.Published)
            {
                throw new InvalidOperationException("Only published jobs can be closed.");
            }
            Status = JobStatus.Closed;
        }

        public void Update
        (
            string title,
            string description,
            string location,
            string department,
            decimal? salaryMin,
            decimal? salaryMax
        )
        {
            if(Status == JobStatus.Closed)
            {
                throw new InvalidOperationException("A closed job cannot be updated.");
            }

            Title = title;
            Description = description;
            Location = location;
            Department = department;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            SetUpdateAt();
        }

    }
}
