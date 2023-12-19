using System.ComponentModel.DataAnnotations;


namespace WebFitnessApp.Data.ViewModels
{
    using static WebFitnessApp.Data.Common.Instructor;

    public class BecomeInstructorFormModel
    {

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        [Phone]

        public string PhoneNumber { get; set; } = null!;
    }
}
