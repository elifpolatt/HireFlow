using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
        {
            builder.ToTable("Applications");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CoverLetter).HasMaxLength(5000);

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.AppliedAt).IsRequired();
            builder.HasOne(x => x.Candidate).WithMany().HasForeignKey(x =>x.CandidateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Job).WithMany().HasForeignKey(x =>x.JobId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => new
            {
                x.CandidateId,
                x.JobId
            }).IsUnique();

        }
    }
}
