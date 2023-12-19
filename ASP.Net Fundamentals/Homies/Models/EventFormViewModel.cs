using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    using static Homies.Data.Common.Event;
    public class EventFormViewModel
    {
        public EventFormViewModel()
        {
            Types = new List<TypeViewModel>();
        }


        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
         ErrorMessage = "Event name must be between 5 and 20 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
      ErrorMessage = "Description must be between 15 and 150 characters.")]
        public string Description { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = null!;
    }
}
