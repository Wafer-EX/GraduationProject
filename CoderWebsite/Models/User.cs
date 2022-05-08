using Microsoft.AspNetCore.Identity;

namespace CoderWebsite.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}