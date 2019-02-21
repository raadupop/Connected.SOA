using Connected.Planning.Domain.Planning.Dto;
using Microsoft.EntityFrameworkCore;

namespace Connected.Planning.Data
{
    public class PlanningDbContext : DbContext 
    {
        public PlanningDbContext(DbContextOptions<PlanningDbContext> optionsBuilder) : base(optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityPlanEntryDto>()
                .HasOne(a => a.ActivityLabel)
                .WithMany(a => a.ActivityPlanEntries)
                .HasForeignKey(a => a.ActivityLabelName);

            modelBuilder.Entity<PersonalPlanDto>()
                .HasMany(p => p.Activities)
                .WithOne(a => a.PersonalPlan)
                .HasForeignKey(a => a.PersonalPlanId);
        }

        public DbSet<PersonalPlanDto> PersonalPlans { get; set; }

        public DbSet<ActivityPlanEntryDto> ActivityPlanEntries { get; set; }

        public DbSet<ActivityLabelDto> ActivityLabels { get; set; }

        public DbSet<ScheduleTemplateDto> ScheduleTemplates { get; set; }

        public DbSet<ScheduleEventDto> ScheduleEvents { get; set; }

        public DbSet<ScheduleOptimizationType> ScheduleOptimizationTypes { get; set; }
    }
}
