using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Data.Entities
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTypeName, MinimumLength = MinTypeName)]
        public string Name { get; set; } = null!;

        [Required] 
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
