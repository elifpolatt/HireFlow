using HireFlow.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Experience : AuditableEntity
    {
        public Guid CandidateId { get; private set; } 

        public string CompanyName { get; private set; } = null!;

        public string Position { get; private set; } = null!;

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public string? Description { get; private set; }

        public Candidate Candidate { get; private set; } = null!;

        private Experience()
        {
        }

        public Experience(
            Guid candidateId,
            string companyName,
            string position,
            DateTime startDate,
            DateTime? endDate,
            string? description
           )
        {
            CandidateId = candidateId;
            CompanyName = companyName;
            Position = position;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        public void Update(
            string companyName,
            string position,
            DateTime startDate,
            DateTime? endDate,
            string? description)
        {
            if (endDate.HasValue && endDate.Value < startDate)
            {
                throw new InvalidOperationException("End date cannot be before start date.");
            }

            CompanyName = companyName;
            Position = position;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;

            SetUpdateAt();
        }
    }
}
