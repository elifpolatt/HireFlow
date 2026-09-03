using HireFlow.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Experience : AuditableEntity
    {
        public Guid CandidateId { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        public Candidate Candidate { get; set; }

        private Experience()
        {
        }

        public Experience(Guid candidateId,
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

        public void Update(string companyName,
            string position,
            DateTime startDate,
            DateTime? endDate,
            string? description)
        {
            CompanyName = companyName;
            Position = position;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;

            SetUpdateAt();
        }
    }
}
