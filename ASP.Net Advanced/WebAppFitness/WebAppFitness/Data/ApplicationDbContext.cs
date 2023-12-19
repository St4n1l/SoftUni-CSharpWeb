using FitnessTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace WebAppFitness.Data
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
           
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;

        public DbSet<FitnessInstructor> FitnessInstructors { get; set; } = null!;

        public DbSet<WorkoutCategory> Categories { get; set; } = null!;

        public DbSet<Workout> Workouts { get; set; } = null!;
      
    }
}