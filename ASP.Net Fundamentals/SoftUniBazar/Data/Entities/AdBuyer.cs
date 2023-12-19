using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Entities
{
    public class AdBuyer
    {
        [ForeignKey(nameof(Buyer))]
        public string BuyerId { get; set; } = null!;

        [Required]
        public IdentityUser Buyer { get; set; } = null!;


        [ForeignKey(nameof(Ad))]
        public int AdId { get; set; }

        [Required]
        public Ad Ad { get; set; } = null!;
    }
}
