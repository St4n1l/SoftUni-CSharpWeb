using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.Models
{
    public class WorkoutCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Common.WorkoutCategoryNameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
