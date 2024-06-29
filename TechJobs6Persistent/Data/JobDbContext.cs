using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.Data
{
    public class JobDbContext : DbContext
    {
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Employer>? Employers { get; set; }
        public DbSet<Skill>? Skills { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasOne(p => p.Employer)
                .WithMany(b => b.Jobs);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Skills)
                .WithMany(s => s.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobSkills",
                    j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    s => s.HasOne<Job>().WithMany().HasForeignKey("JobId"));
        }
    }
}
