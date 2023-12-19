using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Entities;

namespace SoftUniBazar.Models
{
    public class AdAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime AddedOn { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Owner { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;


    }
}
