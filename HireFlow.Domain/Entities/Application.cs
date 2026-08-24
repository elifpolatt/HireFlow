using HireFlow.Domain.Common;
using HireFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Application : AuditableEntity
    {
        public Guid CandidateId { get; private set; }
        public Guid JobId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public string? CoverLetter { get; private set; }
        public DateTime AppliedAt { get; private set; }
        public Candidate Candidate { get; private set; } = null!;
        public Job Job { get; private set; } = null!;
        private Application() { }

        public Application(Guid candidateId, Guid jobId, string? coverLetter)
        {
            CandidateId = candidateId;
            JobId = jobId;
            CoverLetter = coverLetter;
            AppliedAt = DateTime.UtcNow;
            Status = ApplicationStatus.Applied;
        }

        public void UpdateStatus(ApplicationStatus status) {
            Status = status;
            SetUpdateAt();
        }
    }
}
