using Microsoft.AspNetCore.Mvc.Rendering;

namespace SoftUniBazar.Models
{
    public class AdFormViewModel
    {
        public AdFormViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
