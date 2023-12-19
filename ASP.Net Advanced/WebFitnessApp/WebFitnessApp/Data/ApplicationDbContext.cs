using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebFitnessApp.Data.Entities;

namespace WebFitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;

        public DbSet<FitnessInstructor> FitnessInstructors { get; set; } = null!;

        public DbSet<WorkoutCategory> Categories { get; set; } = null!;

        public DbSet<Workout> Workouts { get; set; } = null!;
    }
}