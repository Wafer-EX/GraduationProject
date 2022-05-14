using CoderWebsite.Initializers;
using CoderWebsite.Middleware;
using CoderWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
if (connectionString == null)
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
else builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddIdentity<User, IdentityRole>(opts => {
        opts.Password.RequiredLength = 8;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultUI()
    .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await DbInitializer.InitializeAsync(userManager, roleManager);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<BlazorLoginMiddleware>();
app.UseMiddleware<BlazorLogoutMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();