using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.Common.Category;

namespace SoftUniBazar.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Ads = new List<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; }
    }
}
