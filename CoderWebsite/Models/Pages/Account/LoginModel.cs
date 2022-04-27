using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Account
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}