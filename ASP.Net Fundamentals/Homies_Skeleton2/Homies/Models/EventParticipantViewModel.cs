using Homies.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Models
{
    public class EventParticipantViewModel
    {
        public string HelperId { get; set; } = null!;
        public IdentityUser Helper { get; set; } = null!;

        public int EventId { get; set; }

        public Event Event { get; set; } = null!;
    }
}
