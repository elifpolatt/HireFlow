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
            Status = JobStatus.Published;
        }

        public void Close()
        {
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
