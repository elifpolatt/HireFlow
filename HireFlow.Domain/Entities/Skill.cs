using HireFlow.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Entities
{
    public class Skill : AuditableEntity
    {
        public Guid CandidateId { get; private set; }

        public string Name { get; private set; } = null!;

        public Candidate Candidate { get; private set; } = null!;

        private Skill()
        {
        }

        public Skill(Guid candidateId, string name)
        {
            CandidateId = candidateId;
            Name = name;
        }
    }
}
