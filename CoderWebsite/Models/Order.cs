using CoderWebsite.Components.Account;

namespace CoderWebsite.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Date { get; set; }

        public OrderAppType Type { get; set; }

        public OrderStatus Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}