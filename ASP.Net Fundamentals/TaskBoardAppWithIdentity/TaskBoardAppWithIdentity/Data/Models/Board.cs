using System.ComponentModel.DataAnnotations;
using static TaskBoardAppWithIdentity.Data.DataConstants;

namespace TaskBoardAppWithIdentity.Data.Models
{
    public class Board
    {
        public Board()
        {
            Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(boardMaxName)]
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
