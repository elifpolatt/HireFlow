using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace HireFlow.Persistence.Configurations
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("Interviews");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.InterviewType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MeetingUrl).HasMaxLength(1000);
            builder.Property(x => x.Notes).HasMaxLength(5000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.ScheduleAt).IsRequired();
            builder.HasOne(x => x.Application).WithMany().HasForeignKey(x => x.ApplicationId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => x.ScheduleAt);
        }
    }
}
