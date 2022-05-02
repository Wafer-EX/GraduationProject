using CoderWebsite.Middleware;
using CoderWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
if (connectionString == null)
{
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
}
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<BlazorLoginMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();