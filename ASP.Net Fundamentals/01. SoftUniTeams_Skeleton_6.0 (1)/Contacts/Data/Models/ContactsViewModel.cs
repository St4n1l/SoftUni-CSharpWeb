using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; } = null!;


        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(13, MinimumLength = 10)]
        [RegularExpression("^(?:\\+359|0)(?:\\s|-)?\\d{3}(?:\\s|-)?\\d{2}(?:\\s|-)?\\d{2}(?:\\s|-)?\\d{2}$")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [RegularExpression("^www\\.[A-Za-z0-9\\-]{1,}\\.bg$")]
        [StringLength(int.MaxValue)]
        public string Website { get; set; } = null!;

        public string? Address { get; set; }
    }
}
