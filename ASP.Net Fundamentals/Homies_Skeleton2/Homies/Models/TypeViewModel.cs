using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class TypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTypeName, MinimumLength = MinTypeName)]
        public string Name { get; set; } = null!;
    }
}
