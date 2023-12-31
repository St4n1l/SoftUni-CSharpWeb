﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Entities
{
    public class ApplicationUserContact
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        [Required]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }

        [Required]
        public Contact Contact { get; set; } = null!;
    }
}
