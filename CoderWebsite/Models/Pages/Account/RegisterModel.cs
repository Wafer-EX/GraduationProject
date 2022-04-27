using System.ComponentModel.DataAnnotations;

namespace CoderWebsite.Models.Pages.Account
{
    public class RegisterModel
    {
        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        public string? Middlename { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Compare("Password")]
        public string? PasswordConfirmation { get; set; }
    }
}