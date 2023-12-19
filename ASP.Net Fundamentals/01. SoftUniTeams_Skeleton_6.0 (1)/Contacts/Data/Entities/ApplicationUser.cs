using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ApplicationUsersContacts = new List<ApplicationUserContact>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; } = null!;

        [Required]
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }

    }
}
