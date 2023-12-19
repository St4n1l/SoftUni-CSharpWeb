using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Entities
{
    public class EventParticipant
    {
        
        [ForeignKey(nameof(Helper))]
        public string HelperId { get; set; }
        public IdentityUser Helper { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
