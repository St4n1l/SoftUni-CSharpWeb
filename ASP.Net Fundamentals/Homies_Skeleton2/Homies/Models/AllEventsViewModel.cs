using Microsoft.AspNetCore.Identity;
using Type = Homies.Data.Entities.Type;

namespace Homies.Models
{
    public class AllEventsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IdentityUser Organiser { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime Start { get; set; }

        public string Type { get; set; } = null!;
    }
}
