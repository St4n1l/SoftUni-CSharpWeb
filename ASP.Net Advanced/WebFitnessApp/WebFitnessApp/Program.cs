using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebFitnessApp.Contracts;
using WebFitnessApp.Data;
using WebFitnessApp.Data.Entities;
using WebFitnessApp.Services.Instructor;
using WebFitnessApp.Services.Workout;

namespace WebFitnessApp
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IWorkoutService, WorkoutSerice>();
            builder.Services.AddTransient<IInstructorService, InstructorService>();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();           
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "Areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

            
            app.MapRazorPages();
            app.UseAuthentication();

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                Task.Run(async () =>
                {
                    if(await roleManager.RoleExistsAsync(Admi))
                })
            }


            app.Run();
        }
    }
}