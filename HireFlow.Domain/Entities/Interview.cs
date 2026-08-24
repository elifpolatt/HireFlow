using HireFlow.Domain.Common;
using HireFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Interview : AuditableEntity
    {
        public Guid ApplicationId { get; private set; }

        public DateTime ScheduleAt { get; private set; }
        public string InterviewType { get; private set; } = null!;
        public string? MeetingUrl { get; private set; }
        public string? Notes { get; private set; }
        public InterviewStatus Status { get; private set; }
        public Application Application { get; private set; } = null!;
    
        private Interview() { }

        public Interview(Guid applicationId, DateTime scheduleAt, string interviewType, string? meetingUrl = null)
        {
            ApplicationId = applicationId;
            ScheduleAt = scheduleAt;
            InterviewType = interviewType;
            MeetingUrl = meetingUrl;
            Status = InterviewStatus.Scheduled;
        }

        public void Complete(string? notes)
        {
            Notes = notes;
            Status = InterviewStatus.Completed;
            SetUpdateAt();
        }

        public void Cancel()
        {
            Status = InterviewStatus.Cancelled;
            SetUpdateAt();
        }
    }
}
