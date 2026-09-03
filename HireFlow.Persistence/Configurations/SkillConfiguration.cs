using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder) {

            builder.ToTable("Skills");

            builder.HasKey( x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Candidate).WithMany(x => x.Skills).HasForeignKey(x => x.CandidateId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.CandidateId,
                x.Name
            }).IsUnique();
        }
    }
}
