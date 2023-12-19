using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebFitnessApp.Data.Entities
{
    using static Common.User;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();

            Workouts = new List<Workout>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
