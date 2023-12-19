using FitnessTracker.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Entities
{

    public class GoalUser
    {
        public int GoalId { get; set; }

        [ForeignKey(nameof(GoalId))]
        public Goal Goal { get; set; } = null!;

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
