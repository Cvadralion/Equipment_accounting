using Equipment_accounting.Models;
using Microsoft.AspNetCore.Identity;

namespace Equipment_accounting.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            // Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Technician"))
                await roleManager.CreateAsync(new IdentityRole("Technician"));
            if (!await roleManager.RoleExistsAsync("Teacher"))
                await roleManager.CreateAsync(new IdentityRole("Teacher"));

            // Admin user
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
            string adminLogin = "admin01";

            var adminUser = await userManager.FindByNameAsync(adminLogin);
            if (adminUser == null)
            {
                var newAdminUser = new User()
                {
                    UserName = adminLogin,
                    Name = "Иван",
                    Surname = "Ямщиков"
                };
                await userManager.CreateAsync(newAdminUser, "1234");
                await userManager.AddToRoleAsync(newAdminUser, "Admin");
            }

            // Technician user
            string technicanLogin = "tech01";

            var technicanUser = await userManager.FindByEmailAsync(technicanLogin);
            if (technicanUser == null)
            {
                var newTechnicanUser = new User()
                {
                    UserName = technicanLogin,
                    Name = "Андрей",
                    Surname = "Бочков"
                };
                await userManager.CreateAsync(newTechnicanUser, "12345");
                await userManager.AddToRoleAsync(newTechnicanUser, "Technician");
            }

            // Teacher user
            string teacherLogin = "teach01";

            var teacherUser = await userManager.FindByEmailAsync(teacherLogin);
            if (teacherUser == null)
            {
                var newTeacherUser = new User()
                {
                    UserName = teacherLogin,
                    Name = "Никита",
                    Surname = "Баев"
                };
                await userManager.CreateAsync(newTeacherUser, "123456");
                await userManager.AddToRoleAsync(newTeacherUser, "Teacher");
            }
        }
    }
}