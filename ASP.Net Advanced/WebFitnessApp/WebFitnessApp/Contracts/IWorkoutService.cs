using WebFitnessApp.Data.ViewModels;

namespace WebFitnessApp.Contracts
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutIndexServiceModel>> LastThreeWorkouts();
    }
}
