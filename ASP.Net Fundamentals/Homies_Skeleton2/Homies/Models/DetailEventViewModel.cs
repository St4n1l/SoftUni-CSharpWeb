using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class DetailEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public IdentityUser Organiser { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Type { get; set; } = null!;
    }
}

