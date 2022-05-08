using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoderWebsite.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<News> News { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}