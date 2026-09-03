using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder) {

            builder.ToTable("Experiences");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyName)
                .IsRequired().HasMaxLength(200);

            builder.Property(x => x.Position).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Description).HasMaxLength(3000);

            builder.Property(x => x.StartDate).IsRequired();

            builder.HasOne(x => x.Candidate).WithMany(x => x.Experiences).HasForeignKey(x => x.CandidateId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.CandidateId);
        }
    }
}