using FitnessApp.Data.Entities;
using FitnessTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Goal>().Property(p => p.TargetWeight).HasColumnType("double precision(5,2)");

            builder.Entity<GoalUser>().HasKey(gu => new { gu.GoalId, gu.UserId });

            builder.Entity<User>.
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;

        public DbSet<Goal> Goals { get; set; } = null!;

        public DbSet<FitnessInstructor> FitnessInstructors { get; set; } = null!;

        override public DbSet<IdentityUser> Users { get; set; } = null!;

        public DbSet<Workout> Workouts { get; set; } = null!;
    }
}
