using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Common;

namespace FitnessTracker.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();

            Workouts = new List<Workout>();
        }

        [Required]
        [MaxLength(Common.User.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(Common.User.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
