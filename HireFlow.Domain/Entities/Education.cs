using HireFlow.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Education : AuditableEntity
    {
        public Guid CandidateId { get; private set; }
        public string SchoolName { get; private set; } = null!;
        public string Department { get; private set; } = null!;
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public Candidate Candidate { get; private set; } = null!;

        private Education()
        {

        }

        public Education(Guid candidateId, string schoolName, string department, DateTime startDate, DateTime? endDate)
        {
            if(EndDate.HasValue && endDate.Value < startDate)
            {
                throw new InvalidOperationException("End daet cannot be before start date");
            }
            CandidateId = candidateId;
            SchoolName = schoolName;
            Department = department;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
