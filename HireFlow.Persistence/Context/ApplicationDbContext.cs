using HireFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Candidate> Candidates => Set<Candidate>();

        public DbSet<Domain.Entities.Application> Applications => Set< Domain.Entities.Application>();
        
        public DbSet<Interview> Interviews => Set<Interview>();
        public DbSet<Job> Jobs => Set<Job>();

        public DbSet<Skill> Skills => Set<Skill>();

        public DbSet<Experience> Experiences => Set<Experience>();

        public DbSet<Education> Educations => Set<Education>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
