using System.Runtime.InteropServices;
using WebFitnessApp.Data.ViewModels;

namespace WebFitnessApp.Contracts
{
    public interface IInstructorService
    {
        Task<bool> ExistsById(string userId);

        Task<bool> InstructorWithPhoneNumberExists(string phoneNumber);

        Task<bool> HasWorkouts (string userId);

        Task Create(string userId, BecomeInstructorFormModel model);
    }
}
