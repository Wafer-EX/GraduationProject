using CoderWebsite.Models;
using CoderWebsite.Models.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace CoderWebsite.Middleware
{
    public class BlazorLoginMiddleware
    {
        public static List<(User, LoginModel)> LoginsData { get; private set; } = new List<(User, LoginModel)>();

        private readonly RequestDelegate _next;

        public BlazorLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<User> signInManager)
        {
            if (context.Request.Path == "/login-middleware")
            {
                var user = LoginsData.Last().Item1;
                var loginData = LoginsData.Last().Item2;
                var result = await signInManager.PasswordSignInAsync(user, loginData.Password, loginData.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                    context.Response.Redirect("/account");
                else
                    context.Response.Redirect("/error");

                if (LoginsData.Count > 0)
                    LoginsData.Remove(LoginsData.Last());
            }
            else await _next.Invoke(context);
        }
    }
}