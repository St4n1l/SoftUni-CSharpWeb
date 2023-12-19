using Homies.Data.Entities;

namespace Homies.Models
{
    public class JoinedViewModel
    {
        public string OrganiserId { get; set; } = null!;
        public string Organiser { get; set; } = null!;
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;

        public DateTime Start { get; set; }


    }
}
