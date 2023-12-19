using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WebFitnessApp.Contracts;
using WebFitnessApp.Data;
using WebFitnessApp.Data.Entities;
using WebFitnessApp.Data.ViewModels;

namespace WebFitnessApp.Services.Instructor
{
    public class InstructorService : IInstructorService
    {
        private readonly ApplicationDbContext _data;

        public InstructorService(ApplicationDbContext data)
        {
            _data = data;
        }

        public async Task Create(string userId, BecomeInstructorFormModel model)
        {  
            var instructor = new FitnessInstructor
            {
                UserId = Guid.Parse(userId),
                PhoneNumber = model.PhoneNumber
            };

            await _data.FitnessInstructors.AddAsync(instructor);
            await _data.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await _data.FitnessInstructors.AnyAsync(i => i.UserId.ToString() == userId);
        }

        public async Task<bool> HasWorkouts(string userId)
        {
            return await _data.Workouts.AnyAsync(w => w.Users.Any(u => u.Id.ToString() == userId));
        }

        public async Task<bool> InstructorWithPhoneNumberExists(string phoneNumber)
        {
            return await _data.FitnessInstructors.AnyAsync(i => i.PhoneNumber == phoneNumber);
        }
    }
}
