using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entities
{
    using static Common.ApplicationUser;

    public class ApplicationUser
    {
        public ApplicationUser()
        {
            ApplicationUsersContacts = new List<ApplicationUserContact>();
        }


        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
