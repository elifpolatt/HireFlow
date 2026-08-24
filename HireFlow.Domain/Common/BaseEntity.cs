using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
