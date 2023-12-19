using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Common;

namespace FitnessTracker.Data.Entities
{
    public class FitnessInstructor
    {

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(Common.Instructor.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;


    }
}
