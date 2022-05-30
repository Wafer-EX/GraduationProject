using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoderWebsite.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<News> News { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<FeedbackMessage> FeedbackMessages { get; set; }

        public DbSet<MetaPageDescription> MetaPageDescriptions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => Database.EnsureCreated();
    }
}