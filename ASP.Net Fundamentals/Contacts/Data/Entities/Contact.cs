using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entities
{
    public class Contact
    {
        public Contact()
        {
            ApplicationUsersContacts = new List<ApplicationUserContact>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 10)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(0|\+359)(\s?|\-?)[0-9]{3}(\s?|\-?)[0-9]{2}(\s?|\-?)[0-9]{2}(\s?|\-?)[0-9]{2}$",
            ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.bg$", ErrorMessage = "Invalid website format")]
        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
