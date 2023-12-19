using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Data.Entities
{
    public class User : IdentityUser
    {
        [Key]
       public Guid Id { get; set; }

        [Required]
        override public string UserName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [ForeignKey(nameof(Goal))]
        public int GoalId { get; set; }

        [Required]
        public Goal Goal { get; set; } = null!;

        [ForeignKey(nameof(FitnessInstructor))]
        public int? FitnessInstructorId { get; set; }
        public FitnessInstructor? FitnessInstructor { get; set; }

        public bool IsFitnessInstrucot { get; set; } = false;

    }
}
