using CoderWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace CoderWebsite.Initializers
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@coder.ru";
            string password = "passwd_935806";

            if (await roleManager.FindByNameAsync("admin") == null)
                await roleManager.CreateAsync(new IdentityRole("admin"));

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };

                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}