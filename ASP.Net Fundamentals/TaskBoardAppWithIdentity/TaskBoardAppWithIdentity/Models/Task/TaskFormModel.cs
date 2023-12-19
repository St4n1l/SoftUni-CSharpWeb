using System.ComponentModel.DataAnnotations;
using static TaskBoardAppWithIdentity.Data.DataConstants;

namespace TaskBoardAppWithIdentity.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle)]

    }
}
