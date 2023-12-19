using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using static Homies.Data.DataConstants;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxEventName, MinimumLength = MinEventName)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(MaxEventDescription, MinimumLength = MinEventDescription)]
        public string Description { get; set; } = null!;


        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime End { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]

        public DateTime Start { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();

        public int TypeId { get; set; }

        [Required]
        public Type Type { get; set; } = null!;
    }
}
