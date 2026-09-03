using HireFlow.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Candidate : AuditableEntity
    {
        public Guid UserId { get; private set;  }

        public string? PhoneNumber { get; private set; }
        public DateTime? BirthDate { get; private set; }

        public string? CvUrl { get; private set; }
        public string? LinkedinUrl { get; private set; }
        public string? GithubUrl { get; private set; }
        public int ExperienceYears { get; private set; }
        public string? Summary { get; private set; }
        public User User { get; private set; } = null!;

        public ICollection<Skill> Skills { get; private set; } = new List<Skill>();

        public ICollection<Experience> Experiences { get; private set; } = new List<Experience>();

        public ICollection<Education> Educations { get; private set; } = new List<Education>();
        private Candidate()
        {

        }

        public Candidate(Guid userId)
        {
            UserId = userId;
        }

        public void UpdateProfile(
            string? phoneNumber,
            DateTime? birthDate,
            string? linkedinUrl,
            string? githubUrl,
            int experienceYears,
            string? summary)
        {
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            LinkedinUrl = linkedinUrl;
            GithubUrl = githubUrl;
            ExperienceYears = experienceYears;
            Summary = summary;
        }

        public void UpdateCv(string cvUrl)
        {
            CvUrl = cvUrl;
        }
    }
}
