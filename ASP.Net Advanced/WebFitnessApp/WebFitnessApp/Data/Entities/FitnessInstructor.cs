using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebFitnessApp.Services.Workout;

namespace WebFitnessApp.Data.Entities
{
    public class FitnessInstructor
    {
        public FitnessInstructor()
        {
            Id = Guid.NewGuid();

            CreatedWorkouts = new List<Workout>();
        }


        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(Common.Instructor.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Workout> CreatedWorkouts { get; set; } = null!;


    }
}
