namespace HouseRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.House;

    public class Workout
    {
        public Workout()
        {
            Id = Guid.NewGuid();

            RenterIds = new HashSet<Guid>();

            Renters = new HashSet<ApplicationUser>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public decimal PricePerMonth { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid InstructorId { get; set; }

        public virtual Instructor Agent { get; set; } = null!;

        public virtual ICollection<Guid>? RenterIds { get; set; }

        public virtual ICollection<ApplicationUser>? Renters { get; set; }
    }
}
