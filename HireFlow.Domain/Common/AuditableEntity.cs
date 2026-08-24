using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace HireFlow.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUpdateAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
