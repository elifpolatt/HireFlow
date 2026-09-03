using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SchoolName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Department).IsRequired().HasMaxLength(200);

            builder.Property(x => x.StartDate).IsRequired();

            builder.HasOne(x => x.Candidate).WithMany(x => x.Educations).HasForeignKey(x => x.CandidateId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.CandidateId);
        }
    }
}
