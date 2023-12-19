using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Entities
{
    public class FitnessInstructor
    {
        public FitnessInstructor()
        {
            UsersBeingTrained = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<User> UsersBeingTrained { get; set; }



    }
}
