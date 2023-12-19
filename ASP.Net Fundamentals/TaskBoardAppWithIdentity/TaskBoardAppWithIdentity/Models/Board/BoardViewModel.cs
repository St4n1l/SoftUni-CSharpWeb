using TaskBoardAppWithIdentity.Models.Task;

namespace TaskBoardAppWithIdentity.Models.Board
{
    public class BoardViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
