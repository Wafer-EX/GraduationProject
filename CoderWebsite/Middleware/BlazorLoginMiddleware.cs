using CoderWebsite.Models;
using CoderWebsite.Models.Pages.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace CoderWebsite.Middleware
{
    public class BlazorLoginMiddleware
    {
        public static List<(User, LoginModel)> LoginsData { get; private set; } = new List<(User, LoginModel)>();

        private readonly RequestDelegate next;

        public BlazorLoginMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, NavigationManager navigationManager)
        {
            if (context.Request.Path == "/login-middleware")
            {
                var user = LoginsData.Last().Item1;
                var loginData = LoginsData.Last().Item2;
                var result = await signInManager.PasswordSignInAsync(user, loginData.Password, loginData.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    bool isAdmin = await userManager.IsInRoleAsync(user, "admin");
                    if (isAdmin) context.Response.Redirect("/admin", true);
                    else context.Response.Redirect("/account", true);

                }
                else context.Response.Redirect("/error", true);

                if (LoginsData.Count > 0)
                    LoginsData.Remove(LoginsData.Last());
            }
            else await next.Invoke(context);
        }
    }
}