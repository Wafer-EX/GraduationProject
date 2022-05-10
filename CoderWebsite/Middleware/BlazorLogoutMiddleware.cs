using CoderWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace CoderWebsite.Middleware
{
    public class BlazorLogoutMiddleware
    {
        private readonly RequestDelegate _next;

        public BlazorLogoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<User> signInManager)
        {
            if (context.Request.Path == "/logout-middleware")
            {
                await signInManager.SignOutAsync();
                context.Response.Redirect("/");
            }
            else await _next.Invoke(context);
        }
    }
}