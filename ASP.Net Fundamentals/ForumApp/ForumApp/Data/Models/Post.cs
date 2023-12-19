using System.ComponentModel.DataAnnotations;
using ForumApp.Common;

namespace ForumApp.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(EntityValidations.Post.ContentMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(EntityValidations.Post.ContentMaxLength)]
        public string Content { get; set; } = null!;

    }
}
