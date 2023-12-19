using Microsoft.AspNetCore.Identity;

namespace Library.Data.Entities
{
    public class IdentityUserBook
    {
        public string CollectorId { get; set; } = null!;

        public IdentityUser Collector { get; set; } = null!;

        public int BookId{ get; set; }

        public Book Book { get; set; } = null!;
    }
}
