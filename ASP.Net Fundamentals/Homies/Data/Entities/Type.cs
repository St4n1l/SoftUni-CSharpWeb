using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Entities
{
    using static Common.Type;
    public class Type
    {
        public Type()
        {
            Events = new List<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
