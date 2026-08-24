using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhoneNumber).HasMaxLength(30);

            builder.Property(x => x.CvUrl).HasMaxLength(500);

            builder.Property(x => x.LinkedinUrl).HasMaxLength(500);
            builder.Property(x => x.GithubUrl).HasMaxLength(500);
            builder.Property(x => x.Summary).HasMaxLength(2000);

            builder.HasOne(x => x.User).WithOne().HasForeignKey<Candidate>(x => x.UserId);

            builder.HasIndex(x => x.UserId).IsUnique();
        }
    }
}
