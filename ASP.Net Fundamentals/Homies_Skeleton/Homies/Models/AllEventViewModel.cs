using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class AllEventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public string Type { get; set; }

        public string OrganiserId { get; set; }

        public string Organiser { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime End { get; set; }
    }
}
