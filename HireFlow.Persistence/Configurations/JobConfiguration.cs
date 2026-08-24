using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder) {

            builder.ToTable("Jobs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x =>x.Description).IsRequired();

            builder.Property(x => x.Location).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Department).IsRequired().HasMaxLength(150);
            builder.Property(x => x.SalaryMin).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SalaryMax).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Status).IsRequired();
            // Creator kaydı silinmek istendiğinde ona bağlı kayıtlar varsa silme işlemini engeller (Hata verir).
            builder.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Status);
        }
    }
}
