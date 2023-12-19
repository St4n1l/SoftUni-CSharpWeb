using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.Models
{
    public class FitnessInstructor
    {

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(Common.FitnessInstructorPhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; } = null!;


    }
}
